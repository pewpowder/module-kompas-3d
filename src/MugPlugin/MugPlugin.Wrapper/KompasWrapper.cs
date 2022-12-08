using Kompas6API5;
using Kompas6Constants3D;
using KompasAPI7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MugPlugin.Model;

namespace MugPlugin.Wrapper
{
    /// <summary>
    /// Class for launching the library in Kompass-3D.
    /// </summary>
    public class KompasWrapper
    {
        /// <summary>
        /// Kompas-3D object.
        /// </summary>
        private KompasObject _kompas;

        /// <summary>
        /// Part of document.
        /// </summary>
        private ksPart _part;

        /// <summary>
        /// Document 3D.
        /// </summary>
        private ksDocument3D _document;


        /// <summary>
        /// Start Kompas-3D.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void StartKompas()
        {
            try
            {
                if (_kompas != null)
                {
                    _kompas.Visible = true;
                    _kompas.ActivateControllerAPI();
                }

                if (_kompas != null) return;
                {
                    var kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
                    _kompas = (KompasObject)Activator.CreateInstance(kompasType);
                    StartKompas();
                    if (_kompas == null)
                    {
                        throw new Exception("Can't open Kompas3D.");
                    }
                }
            }
            catch (COMException)
            {
                _kompas = null;
                StartKompas();
            }
        }

        /// <summary>
        /// Create kompas 3d document.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public void CreateDocument()
        {
            try
            {
                _document = (ksDocument3D)_kompas.Document3D();
                _document.Create();
                _document = (ksDocument3D)_kompas.ActiveDocument3D();
            }
            catch
            {
                throw new ArgumentException("Can't build detail.");
            }
        }

        /// <summary>
        /// Set detail properties: color and name.
        /// </summary>
        public void SetProperties()
        {
            _part = (ksPart)_document.GetPart((short)Part_Type.pTop_Part);
            _part.name = "Mug";
            _part.SetAdvancedColor(3407871, 0.8, 0.8, 0.8, 0.8);
            _part.Update();
        }

        /// <summary>
        /// Create sketch.
        /// </summary>
        /// <param name="type">Sketch plane.</param>
        /// <param name="offset">Plane offset.</param>
        /// <returns>Kompas 3d sketch.</returns>
        public KompasSketch CreateSketch(int type, double offset = 0)
        {
            return new KompasSketch(_part, type, offset);
        }

        /// <summary>
        /// Sketch extrusion.
        /// </summary>
        /// <param name="kompasSketch">Kompas sketch.</param>
        /// <param name="depth">Extrusion depth.</param>
        /// <param name="type">Extrusion direction.</param>
        public void Extrude(KompasSketch kompasSketch, double depth, bool type)
        {
            ksEntity extrudeEntity = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
            ksBaseExtrusionDefinition extrudeDefinition =
                (ksBaseExtrusionDefinition)extrudeEntity.GetDefinition();
            if (type == false)
            {
                extrudeDefinition.directionType = (short)Direction_Type.dtReverse;
            }
            else
            {
                extrudeDefinition.directionType = (short)Direction_Type.dtNormal;
            }
            extrudeDefinition.SetSideParam(type, (short)End_Type.etBlind, depth);
            extrudeDefinition.SetSketch(kompasSketch.Sketch);
            extrudeEntity.Create();
        }

        /// <summary>
        /// Sketch cut extrusion.
        /// </summary>
        /// <param name="kompasSketch">Kompas sketch.</param>
        /// <param name="depth">Extrusion depth.</param>
        /// <param name="type">Extrusion direction.</param>
        public void CutExtrude(KompasSketch kompasSketch, double depth, bool type)
        {
            ksEntity extrudeEntity = (ksEntity)_part.NewEntity((int)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition extrudeDefinition = (ksCutExtrusionDefinition)extrudeEntity.GetDefinition();
            if (type == false)
            {
                extrudeDefinition.directionType = (short)Direction_Type.dtReverse;
            }
            else
            {
                extrudeDefinition.directionType = (short)Direction_Type.dtNormal;
            }
            extrudeDefinition.SetSketch(kompasSketch.Sketch);
            ksExtrusionParam extrudeParam = (ksExtrusionParam)extrudeDefinition.ExtrusionParam();
            extrudeParam.depthNormal = depth;
            extrudeEntity.Create();
        }

        /// <summary>
        /// Sketch rotation extrusion.
        /// </summary>
        /// <param name="kompasSketch">Kompas sketch.</param>
        public void ExtrudeRotation(KompasSketch kompasSketch)
        {
            ksEntity bossRotated = _part.NewEntity((short)Obj3dType.o3d_bossRotated);
            ksBossRotatedDefinition bossRotatedDefinition = bossRotated.GetDefinition();
            bossRotatedDefinition.directionType = (short)Direction_Type.dtNormal;
            bossRotatedDefinition.SetSketch(kompasSketch.Sketch);
            bossRotatedDefinition.SetSideParam(true, 180);
            bossRotated.Create();
        }

        /// <summary>
        /// Rounds edges.
        /// </summary>
        /// <param name="radius">Rounded angle.</param>
        public void Fillet(double radius)
        {
            var roundedEdges = GetCylinderFaces();
            if (roundedEdges.Count.Equals(0))
            {
                throw new Exception("Edge collection is empty.");
            }

            var filletEntity = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_fillet);
            ksFilletDefinition filletDefinition = (ksFilletDefinition)filletEntity.GetDefinition();
            ksEntityCollection items = (ksEntityCollection)filletDefinition.array();

            filletDefinition.radius = radius;
            roundedEdges.ForEach(edge => items.Add(edge));
            filletEntity.Create();
        }

        /// <summary>
        /// Returns all cylindrical faces of a part.
        /// </summary>
        /// <returns>List of Cylindrical Faces.</returns>
        private List<ksFaceDefinition> GetCylinderFaces()
        {
            var body = (ksBody)_part.GetMainBody();
            var faces = (ksFaceCollection)body.FaceCollection();

            var facesCount = faces.GetCount();
            if (facesCount == 0)
            {
                return new List<ksFaceDefinition>();
            }

            var cylinderFaces = new List<ksFaceDefinition>();
            var i = 0;
            while (faces.Next() != null)
            {
                var currentFace = (ksFaceDefinition)faces.GetByIndex(i);
                if (currentFace.IsValid())
                {
                    cylinderFaces.Add(currentFace);
                }

                ++i;
            }

            return cylinderFaces;
        }

    }
}
