﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;
using RussLibrary.Xml;
using RussLibrary;
namespace VesselDataLibrary
{
    [XmlConversionRoot("vessel_data")]
    public class VesselDataObject : DependencyObject
    {
        public VesselDataObject()
        {
            HullRaces = new ObservableCollection<HullRace>();
            Vessels = new ObservableCollection<Vessel>();
        }
        /*
         * Sample Xml from file:
         *
         *  <vessel_data version="1.66">

  <hullRace ID="0" name="USFP" keys="player"/>
  <vessel    uniqueID="0"    side="0"       classname="Light Cruiser" broadType="player">
    <art     meshfile="dat/artemis.dxs"    diffuseFile="dat/artemis_diffuse.png"    
             glowFile="dat/artemis_illum.png"    specularFile="dat/artemis_specular.png" scale="0.2" pushRadius="150"/>
    <internal_data file="dat/artemis.snt" />
    <shields front="80" back="80" />
    <performance turnrate="0.004" topspeed="0.6" />
    <beam_port x="-102.14" y="8.35" z="258.74" damage="12" arcwidth="0.4" cycletime="6.0" range="1000"/>
    <beam_port x=" 102.14" y="8.35" z="258.74" damage="12" arcwidth="0.4" cycletime="6.0" range="1000"/>
    <torpedo_tube x="0" y="8.35" z="258.74"/>
    <torpedo_tube x="0" y="8.35" z="258.74"/>
    <torpedo_storage type="0" amount="8" />  <!-- Type 1 Homing"-->
    <torpedo_storage type="1" amount="2" />  <!-- Type 4 LR Nuke-->
    <torpedo_storage type="2" amount="6" />  <!-- Type 6 Mine"-->
    <torpedo_storage type="3" amount="4" />  <!-- Type 9 ECM"-->
    <engine_port x=" 82.93" y="5" z="-240.89" />
    <engine_port x="-82.93" y="5" z="-240.89" />
    <engine_port x="0" y="-9.22" z="-300" />
    <engine_port x="0" y="29.64" z="-300" />
    <long_desc text="USFP Cruiser^Standard long patrol vessel of the USFP.^2 forward beams^2 Torpedo tubes^Stores for 2 nukes, 8 homing, 6 mines, 4 ECM." />
  </vessel>
        </vessel_data>
         * */
        public static readonly DependencyProperty VersionProperty =
          DependencyProperty.Register("Version", typeof(string),
          typeof(VesselDataObject));

        [XmlConversion("version")]
        public string Version
        {
            get
            {
                return (string)this.UIThreadGetValue(VersionProperty);

            }
            set
            {
                this.UIThreadSetValue(VersionProperty, value);

            }
        }


        public static readonly DependencyProperty HullRacesProperty =
          DependencyProperty.Register("HullRaces", typeof(ObservableCollection<HullRace>),
          typeof(VesselDataObject));
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly"), XmlConversion("hullRace")]
        public ObservableCollection<HullRace> HullRaces
        {
            get
            {
                return (ObservableCollection<HullRace>)this.UIThreadGetValue(HullRacesProperty);

            }
            set
            {
                this.UIThreadSetValue(HullRacesProperty, value);

            }
        }


        public static readonly DependencyProperty VesselsProperty =
          DependencyProperty.Register("Vessels", typeof(ObservableCollection<Vessel>),
          typeof(VesselDataObject));
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly"), XmlConversion("vessel")]
        public ObservableCollection<Vessel> Vessels
        {
            get
            {
                return (ObservableCollection<Vessel>)this.UIThreadGetValue(VesselsProperty);

            }
            set
            {
                this.UIThreadSetValue(VesselsProperty, value);

            }
        }
    }
}
