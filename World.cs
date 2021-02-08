using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gurpsmoontest
{
    public class World
    {
        private int worldType;
        private double atmomass;
        private int hydrocoeff;//as multiple of 10% of surface
        private int surfacetemp;//in  kelvins
        private double blackbody;//in kelvins
        private double density1;//Earths
        private double density2;//g per cc
        private double diameter;//in multiples of the diameter of earth
        private double diameter2;//in miles
        private double surfacegravity;//in G
        private double mass;//in Earths
        private double pressure;//in atm
        private World[] sats;//array to hold planet's moons

        public World()
        {//initialize all values to zero for safety
            worldType = 0;
            atmomass = 0;
            hydrocoeff = 0;
            surfacetemp = 0;
            blackbody = 0;
            density1 = 0;
            density2 = 0;
            diameter = 0;
            diameter2 = 0;
            surfacegravity = 0;
            mass = 0;
            pressure = 0;
        }
        // getters and setters for ALL THE THINGS
        public void setType(int x)
        {
            this.worldType = x;
        }

        public int getType() {

            return this.worldType;
        }

        public void setAtmoMass(double x)
        {
            this.atmomass = x;
        }

        public double getAtmoMass()
        {
            return this.atmomass;
        }

        public void setHydro(int x) {
            this.hydrocoeff = x;        
        }

        public int getHydro() {
            return hydrocoeff;
        }

        public void setSurfaceTemp(int x)
        {
            this.surfacetemp = x;
        }

        public int getSurfaceTemp()
        {
            return this.surfacetemp;
        }
        
        public void setBlackBody(double x) {
            this.blackbody = x;
        }

        public double getBlackBody()
        {
            return this.blackbody;
        }
        
        public void setEarthDensity(double x) {
            this.density1 = x;
        }
        public double getEarthDensity() {
            return this.density1;
        }
        
        public void setMetricDensity(double x) {
            this.density2 = x;
        }

        public double getMetricDensity()
        {
            return this.density2;
        }
        
        public void setEarthsDiameter(double x) {
            this.diameter = x;
        }
        public double getEarthsDiameter() {
            return this.diameter;
        }

        public void setMilesDiameter(double x) {
            this.diameter2 = x;
        }

        public double getMilesDiameter() {
            return this.diameter2;
        }

        public void setSurfaceGravity(double x) {
            this.surfacegravity = x;
        }
        public double getSurfaceGravity() {
            return this.surfacegravity;
        }
        public void setMass(double x) {
            this.mass = x;
        }
        public double getMass() {
            return this.mass;
        }
        public void setPressure(double x) {
            this.pressure = x;
        }
        public double getPressure() {
            return this.pressure;
        }
       
    }
}