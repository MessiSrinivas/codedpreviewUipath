using DecodeTest.ObjectRepository;
using System;
using System.Collections.Generic;
using System.Data;
using UiPath.CodedWorkflows;
using UiPath.Core;
using UiPath.Core.Activities.Storage;
using UiPath.Excel;
using UiPath.Excel.Activities;
using UiPath.Excel.Activities.API;
using UiPath.Excel.Activities.API.Models;
using UiPath.Orchestrator.Client.Models;
using UiPath.Testing;
using UiPath.Testing.Activities.TestData;
using UiPath.Testing.Activities.TestDataQueues.Enums;
using UiPath.Testing.Enums;
using UiPath.UIAutomationNext.API.Contracts;
using UiPath.UIAutomationNext.API.Models;
using UiPath.UIAutomationNext.Enums;

namespace DecodeTest
{
    public class AdactinLogIn : CodedWorkflow
    {
        private TestData hoteltestdata;
        [Workflow]
        public void Execute()
        {
            // To start using services, use IntelliSense (CTRL + Space) to discover the available services:
            // e.g. system.GetAsset(...)
            // For accessing UI Elements from Object Repository, you can use the Descriptors class e.g:
            // var screen = uiAutomation.Open(Descriptors.MyApp.FirstScreen);
            // screen.Click(Descriptors.MyApp.FirstScreen.SettingsButton);
            var homescreen = uiAutomation.Open("LogInHomeScreen");
            testdata();
            homescreen.TypeInto("Username", hoteltestdata.username);
            homescreen.TypeInto("Password", hoteltestdata.passW);
            homescreen.Click("Login");
            var searchhotel = uiAutomation.Attach("SearchHotelScreen");
            searchhotel.SelectItem("- Select Location -", "Sydney");
            searchhotel.SelectItem("Hotels", "Hotel Sunshine");
            searchhotel.SelectItem("Room Type", "Standard");
            searchhotel.SelectItem("Number of Rooms", "1 - One");
            searchhotel.TypeInto("Check In", hoteltestdata.dateIn);
            searchhotel.TypeInto("CheckoutDate", hoteltestdata.dateout);
            searchhotel.SelectItem("Adult Room", "1 - One");
            searchhotel.Click("Search");
            var hotellist = uiAutomation.Attach("HotelListScreen");
            var hotelselected = hotellist.GetText("Hotel Sunshine");
            Log(hotelselected);
            testing.VerifyExpression(hotelselected == hoteltestdata.expectedhotel, "The expected hotel is", true, "Verify expression", true, false);
        }

        // Code Generation:
        // opeaan amazon website
        void YourMethod()
        {
            var amazonApp = uiAutomation.Open("Amazon", "Amazon");
            ;
        }

        public void testdata()
        {
            hoteltestdata = new TestData();
            hoteltestdata.username = "TestingXpertsDemo";
            hoteltestdata.passW = "Testing@123";
            hoteltestdata.dateIn = "01/02/2024";
            hoteltestdata.dateout = "02/02/2024";
            hoteltestdata.expectedhotel = "Hotel Sunshine";
        }
    }
}