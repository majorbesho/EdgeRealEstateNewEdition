namespace EdgeRealEstate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xx : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abstracts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WorkOrderNumber = c.String(),
                        Cost = c.String(),
                        Contractor = c.String(),
                        Project = c.String(),
                        Date = c.DateTime(nullable: false),
                        EngineerApproval = c.Boolean(nullable: false),
                        CompletionRate = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AdditionalSpecifications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Specification = c.String(),
                        Cost = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ExecutionDuration = c.String(),
                        Connected = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.amiraDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        MasterId = c.Int(),
                        IsDeleted = c.Boolean(),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.amiraMasters", t => t.MasterId)
                .Index(t => t.MasterId);
            
            CreateTable(
                "dbo.amiraMasters",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ARname = c.String(),
                        ENname = c.String(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AssignedSuppliers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderNumber = c.Int(nullable: false),
                        ContractorNumber = c.String(),
                        SupervisingEngineerNumber = c.String(),
                        SupervisingEngineer = c.String(),
                        ReceivingEngineer = c.String(),
                        SpecialSpecifications = c.String(),
                        Notes = c.String(),
                        CreateContract = c.Boolean(nullable: false),
                        MainProjectNumber = c.String(),
                        SubprojectNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        ConstructionMaterialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ConstructionMaterials", t => t.ConstructionMaterialId)
                .Index(t => t.ConstructionMaterialId);
            
            CreateTable(
                "dbo.ConstructionMaterials",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MaterialName = c.String(),
                        MasuringUnit = c.String(),
                        Length = c.String(),
                        Width = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Brand = c.String(),
                        Type = c.String(),
                        effective = c.Boolean(nullable: false),
                        ProcessingTime = c.String(),
                        Specifications = c.String(),
                        Notes = c.String(),
                        Image = c.String(),
                        Quantity = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ConstructionMaterialPriceVariables",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        lastPrice = c.String(),
                        lastSupplier = c.String(),
                        ExecutiveEngineerPrice = c.String(),
                        Marketprice = c.String(),
                        ConstructionMaterialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ConstructionMaterials", t => t.ConstructionMaterialId)
                .Index(t => t.ConstructionMaterialId);
            
            CreateTable(
                "dbo.MaterialDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        price = c.Decimal(precision: 18, scale: 2),
                        ConstructionMaterialId = c.Int(nullable: false),
                        MianItemsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ConstructionMaterials", t => t.ConstructionMaterialId)
                .ForeignKey("dbo.MianItems", t => t.MianItemsId)
                .Index(t => t.ConstructionMaterialId)
                .Index(t => t.MianItemsId);
            
            CreateTable(
                "dbo.MianItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aname = c.String(nullable: false, maxLength: 50),
                        Ename = c.String(),
                        NoOfDaies = c.Int(nullable: false),
                        Description = c.String(),
                        AttachedId = c.String(),
                        DegreeOfExcellenceId = c.Int(nullable: false),
                        HaveItem = c.Boolean(nullable: false),
                        Nots = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MianItemsAttachments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        MianItemsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MianItems", t => t.MianItemsId)
                .Index(t => t.MianItemsId);
            
            CreateTable(
                "dbo.Stage",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Aname = c.String(nullable: false, maxLength: 50),
                        Ename = c.String(),
                        code = c.String(),
                        IsHaveItem = c.Boolean(nullable: false),
                        BeginDateAcutely = c.String(),
                        EndDateAcutely = c.String(),
                        lastCost = c.Single(nullable: false),
                        nots = c.String(),
                        MianItems_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.MianItems", t => t.MianItems_Id)
                .Index(t => t.MianItems_Id);
            
            CreateTable(
                "dbo.ProjectStages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartDate = c.String(),
                        EndDate = c.String(),
                        Duration = c.String(),
                        ProjectID = c.Int(nullable: false),
                        StageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Project", t => t.ProjectID)
                .ForeignKey("dbo.Stage", t => t.StageID)
                .Index(t => t.ProjectID)
                .Index(t => t.StageID);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Aname = c.String(nullable: false),
                        Ename = c.String(),
                        LandNo = c.String(),
                        LandSize = c.String(),
                        attachedFileAndPic = c.Int(nullable: false),
                        MaxLevelForContributions = c.String(),
                        ImgURL = c.String(maxLength: 2048),
                        BeginDateAcutely = c.DateTime(nullable: false),
                        BeginDateExpected = c.DateTime(nullable: false),
                        EndDateAcutely = c.DateTime(nullable: false),
                        EndDateExpected = c.DateTime(nullable: false),
                        IsExtand = c.Boolean(nullable: false),
                        FlatNO = c.Int(nullable: false),
                        RoveNO = c.Int(nullable: false),
                        ShopNO = c.Int(nullable: false),
                        LevelNO = c.Int(nullable: false),
                        VellaNO = c.Int(nullable: false),
                        AdminstrationLevelNO = c.Int(nullable: false),
                        ProjectDescriptionID = c.Int(nullable: false),
                        nots = c.String(maxLength: 2048),
                        MainProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.MainProject", t => t.MainProjectId)
                .Index(t => t.MainProjectId);
            
            CreateTable(
                "dbo.EmployeeSales",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        EmpId = c.Int(nullable: false),
                        FlatId = c.Int(nullable: false),
                        VillaId = c.Int(nullable: false),
                        FlatCode = c.String(),
                        VillaCode = c.String(),
                        CustId = c.Int(nullable: false),
                        Paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentSystemId = c.Int(nullable: false),
                        IsPrint = c.Boolean(nullable: false),
                        Details = c.String(),
                        Note = c.String(),
                        AdvancePayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDeleted = c.Boolean(nullable: false),
                        Flat_id = c.Int(),
                        Employee_Id = c.Int(),
                        Villa_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Flat", t => t.Flat_id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Customers", t => t.CustId)
                .ForeignKey("dbo.Flat", t => t.FlatId)
                .ForeignKey("dbo.PaymentSystems", t => t.PaymentSystemId)
                .ForeignKey("dbo.Project", t => t.ProjectId)
                .ForeignKey("dbo.Villa", t => t.Villa_id)
                .ForeignKey("dbo.Villa", t => t.VillaId)
                .Index(t => t.ProjectId)
                .Index(t => t.FlatId)
                .Index(t => t.VillaId)
                .Index(t => t.CustId)
                .Index(t => t.PaymentSystemId)
                .Index(t => t.Flat_id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Villa_id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ARName = c.String(nullable: false),
                        ENName = c.String(),
                        Type = c.Boolean(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        salesManID = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        managerName = c.String(),
                        LKCountryId = c.Int(nullable: false),
                        LKCityId = c.Int(nullable: false),
                        Address = c.String(),
                        tele1 = c.String(),
                        tele2 = c.String(),
                        Fax = c.String(),
                        Site = c.String(),
                        Email = c.String(),
                        Mailbox = c.String(),
                        isCredit = c.Boolean(nullable: false),
                        timeLimit = c.Int(nullable: false),
                        moneyLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        discountPer = c.Double(nullable: false),
                        autoDiscount = c.Boolean(nullable: false),
                        intialValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        currentValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        hashCol = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Notes = c.String(),
                        pricePlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LKCountries", t => t.LKCountryId)
                .ForeignKey("dbo.LKAccounts", t => t.AccountId)
                .ForeignKey("dbo.City", t => t.LKCityId)
                .Index(t => t.AccountId)
                .Index(t => t.LKCountryId)
                .Index(t => t.LKCityId);
            
            CreateTable(
                "dbo.CustomerSelectFlats",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        FlatId = c.Int(nullable: false),
                        CurrntlyDate = c.DateTime(),
                        CustomerPaiedId = c.Int(nullable: false),
                        CostMony = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Vet = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustPaperPayment_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.CustPaperPayments", t => t.CustPaperPayment_id)
                .ForeignKey("dbo.Flat", t => t.FlatId)
                .Index(t => t.CustomerId)
                .Index(t => t.FlatId)
                .Index(t => t.CustPaperPayment_id);
            
            CreateTable(
                "dbo.CustPaperPayments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        customerId = c.Int(),
                        paid = c.Decimal(precision: 18, scale: 2),
                        notes = c.String(),
                        refType = c.String(),
                        refID = c.Int(nullable: false),
                        paidMethod = c.String(),
                        salesManId = c.Int(),
                        indate = c.DateTime(),
                        empId = c.Int(),
                        hashCol = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                        billId = c.Int(),
                        Employee_Id = c.Int(),
                        Employee_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.customerId)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id1)
                .ForeignKey("dbo.Employees", t => t.empId)
                .ForeignKey("dbo.Employees", t => t.salesManId)
                .Index(t => t.customerId)
                .Index(t => t.salesManId)
                .Index(t => t.empId)
                .Index(t => t.Employee_Id)
                .Index(t => t.Employee_Id1);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ARName = c.String(nullable: false),
                        ENName = c.String(),
                        age = c.Int(nullable: false),
                        Degree = c.String(),
                        LKNationalityId = c.Int(nullable: false),
                        religion = c.String(),
                        isFemale = c.Boolean(nullable: false),
                        nearTele = c.String(),
                        tele = c.String(),
                        nationalTele = c.String(),
                        isActive = c.Boolean(nullable: false),
                        address = c.String(),
                        LKBranchId = c.Int(nullable: false),
                        startDate = c.String(),
                        ContractDur = c.String(),
                        HashCol = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Description = c.String(),
                        DOB = c.DateTime(nullable: false),
                        POB = c.DateTime(nullable: false),
                        SocStatus = c.String(),
                        TitleId = c.Int(nullable: false),
                        section = c.String(),
                        Email = c.String(),
                        password = c.String(),
                        salary = c.Double(nullable: false),
                        Housingallowance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LKBranches", t => t.LKBranchId)
                .ForeignKey("dbo.LKNationalities", t => t.LKNationalityId)
                .ForeignKey("dbo.LKTitles", t => t.TitleId)
                .Index(t => t.LKNationalityId)
                .Index(t => t.LKBranchId)
                .Index(t => t.TitleId);
            
            CreateTable(
                "dbo.ContPaperPayments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ContributorId = c.Int(nullable: false),
                        paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        notes = c.String(),
                        refType = c.String(),
                        refID = c.Int(nullable: false),
                        paidMethod = c.String(),
                        ContPaperPaymentType = c.String(),
                        salesManId = c.Int(nullable: false),
                        indate = c.DateTime(nullable: false),
                        empId = c.Int(nullable: false),
                        hashCol = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                        billId = c.Int(nullable: false),
                        ProjectId = c.Int(),
                        Employee_Id = c.Int(),
                        Employee1_Id = c.Int(),
                        Employee_Id1 = c.Int(),
                        Employee_Id2 = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Contributors", t => t.ContributorId)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Employees", t => t.Employee1_Id)
                .ForeignKey("dbo.Project", t => t.ProjectId)
                .ForeignKey("dbo.Employees", t => t.Employee_Id1)
                .ForeignKey("dbo.Employees", t => t.Employee_Id2)
                .Index(t => t.ContributorId)
                .Index(t => t.ProjectId)
                .Index(t => t.Employee_Id)
                .Index(t => t.Employee1_Id)
                .Index(t => t.Employee_Id1)
                .Index(t => t.Employee_Id2);
            
            CreateTable(
                "dbo.Contributors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ARName = c.String(),
                        EName = c.String(),
                        address = c.String(),
                        BankAccount = c.String(),
                        Evaluation = c.Int(nullable: false),
                        salesManID = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Email = c.String(),
                        Tele1 = c.String(),
                        Tele2 = c.String(),
                        WebSite = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ContPaperReceipts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ContributorId = c.Int(nullable: false),
                        paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        notes = c.String(),
                        refType = c.String(),
                        refID = c.Int(nullable: false),
                        paidMethod = c.String(),
                        ContPaperReceiptType = c.String(),
                        salesManId = c.Int(nullable: false),
                        indate = c.DateTime(nullable: false),
                        empId = c.Int(nullable: false),
                        hashCol = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                        billId = c.Int(nullable: false),
                        ProjectId = c.Int(),
                        Employee_Id = c.Int(),
                        Employee1_Id = c.Int(),
                        Employee_Id1 = c.Int(),
                        Employee_Id2 = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Contributors", t => t.ContributorId)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Employees", t => t.Employee1_Id)
                .ForeignKey("dbo.Project", t => t.ProjectId)
                .ForeignKey("dbo.Employees", t => t.Employee_Id1)
                .ForeignKey("dbo.Employees", t => t.Employee_Id2)
                .Index(t => t.ContributorId)
                .Index(t => t.ProjectId)
                .Index(t => t.Employee_Id)
                .Index(t => t.Employee1_Id)
                .Index(t => t.Employee_Id1)
                .Index(t => t.Employee_Id2);
            
            CreateTable(
                "dbo.contractorPaperPayments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        contractorId = c.Int(nullable: false),
                        paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        notes = c.String(),
                        refType = c.String(),
                        refID = c.Int(nullable: false),
                        paidMethod = c.String(),
                        salesManId = c.Int(nullable: false),
                        indate = c.DateTime(nullable: false),
                        empId = c.Int(nullable: false),
                        hashCol = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                        billId = c.Int(nullable: false),
                        Employee_Id = c.Int(),
                        Employee_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.contractors", t => t.contractorId)
                .ForeignKey("dbo.Employees", t => t.empId)
                .ForeignKey("dbo.Employees", t => t.salesManId)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id1)
                .Index(t => t.contractorId)
                .Index(t => t.salesManId)
                .Index(t => t.empId)
                .Index(t => t.Employee_Id)
                .Index(t => t.Employee_Id1);
            
            CreateTable(
                "dbo.contractors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ARName = c.String(nullable: false),
                        ENName = c.String(),
                        Type = c.Boolean(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        salesManID = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        managerName = c.String(),
                        LKCountryId = c.Int(nullable: false),
                        LKCityId = c.Int(nullable: false),
                        Address = c.String(),
                        tele1 = c.String(),
                        tele2 = c.String(),
                        Fax = c.String(),
                        Site = c.String(),
                        Email = c.String(),
                        Mailbox = c.String(),
                        isCredit = c.Boolean(nullable: false),
                        timeLimit = c.Int(nullable: false),
                        moneyLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        discountPer = c.Double(nullable: false),
                        autoDiscount = c.Boolean(nullable: false),
                        intialValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        currentValue = c.Decimal(precision: 18, scale: 2),
                        hashCol = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Notes = c.String(),
                        pricePlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LKAccounts", t => t.AccountId)
                .ForeignKey("dbo.City", t => t.LKCityId)
                .ForeignKey("dbo.LKCountries", t => t.LKCountryId)
                .Index(t => t.AccountId)
                .Index(t => t.LKCountryId)
                .Index(t => t.LKCityId);
            
            CreateTable(
                "dbo.contractorPaperReceipts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        contractorId = c.Int(nullable: false),
                        paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        notes = c.String(),
                        refType = c.String(),
                        refID = c.Int(nullable: false),
                        paidMethod = c.String(),
                        salesManId = c.Int(nullable: false),
                        indate = c.DateTime(nullable: false),
                        empId = c.Int(nullable: false),
                        hashCol = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                        billId = c.Int(nullable: false),
                        Employee_Id = c.Int(),
                        Employee_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.contractors", t => t.contractorId)
                .ForeignKey("dbo.Employees", t => t.empId)
                .ForeignKey("dbo.Employees", t => t.salesManId)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id1)
                .Index(t => t.contractorId)
                .Index(t => t.salesManId)
                .Index(t => t.empId)
                .Index(t => t.Employee_Id)
                .Index(t => t.Employee_Id1);
            
            CreateTable(
                "dbo.LKAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ARName = c.String(),
                        ENName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        HashCol = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aname = c.String(nullable: false, maxLength: 50),
                        Ename = c.String(),
                        Notss = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MainLand",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Aname = c.String(nullable: false, maxLength: 250),
                        Ename = c.String(),
                        TypesInvestmentTag = c.String(),
                        TypesInvestmentTag1 = c.String(),
                        TypesInvestmentTag2 = c.String(),
                        TypesInvestmentTag3 = c.String(),
                        TypesInvestmentTag4 = c.String(),
                        TypesInvestmentTag5 = c.DateTime(),
                        ImgURL = c.String(maxLength: 2048),
                        longitude = c.String(),
                        Latitude = c.String(),
                        LandNo = c.String(),
                        nots = c.String(maxLength: 2048),
                        Attached = c.Int(nullable: false),
                        StreetID = c.Int(nullable: false),
                        DistrictID = c.Int(nullable: false),
                        CitiesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.City", t => t.CitiesID)
                .ForeignKey("dbo.District", t => t.DistrictID)
                .ForeignKey("dbo.Street", t => t.StreetID)
                .Index(t => t.StreetID)
                .Index(t => t.DistrictID)
                .Index(t => t.CitiesID);
            
            CreateTable(
                "dbo.District",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aname = c.String(nullable: false, maxLength: 50),
                        Ename = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Flat",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Aname = c.String(nullable: false, maxLength: 50),
                        Ename = c.String(),
                        code = c.String(),
                        FlotSize = c.Int(nullable: false),
                        BeginDateAcutely = c.DateTime(nullable: false),
                        BeginDateExpected = c.DateTime(nullable: false),
                        EndDateAcutely = c.DateTime(nullable: false),
                        EndDateExpected = c.DateTime(nullable: false),
                        ImgUrl = c.String(),
                        AttachedId = c.String(),
                        Level = c.Int(nullable: false),
                        BedroomNo = c.Int(nullable: false),
                        resptionNo = c.Int(nullable: false),
                        Nots = c.String(),
                        NewType = c.String(),
                        FlatTypeId = c.Int(nullable: false),
                        BuildingId = c.Int(nullable: false),
                        ProjectsId = c.Int(nullable: false),
                        DegreeOfExcellenceId = c.Int(nullable: false),
                        MainLand_id = c.Int(),
                        MainProject_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Buildings", t => t.BuildingId)
                .ForeignKey("dbo.DegreeOfExcellence", t => t.DegreeOfExcellenceId)
                .ForeignKey("dbo.FlatType", t => t.FlatTypeId)
                .ForeignKey("dbo.Project", t => t.ProjectsId)
                .ForeignKey("dbo.MainLand", t => t.MainLand_id)
                .ForeignKey("dbo.MainProject", t => t.MainProject_id)
                .Index(t => t.FlatTypeId)
                .Index(t => t.BuildingId)
                .Index(t => t.ProjectsId)
                .Index(t => t.DegreeOfExcellenceId)
                .Index(t => t.MainLand_id)
                .Index(t => t.MainProject_id);
            
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Level = c.String(),
                        Nots = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DegreeOfExcellence",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aname = c.String(nullable: false, maxLength: 50),
                        Ename = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FlatAttachments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        FlatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Flat", t => t.FlatId)
                .Index(t => t.FlatId);
            
            CreateTable(
                "dbo.FlatType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aname = c.String(maxLength: 50),
                        Ename = c.String(),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MainLandAttachments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        MainLandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MainLand", t => t.MainLandId)
                .Index(t => t.MainLandId);
            
            CreateTable(
                "dbo.MainProject",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Aname = c.String(nullable: false, maxLength: 250),
                        Ename = c.String(),
                        TotalLandSize = c.String(),
                        TypesInvestment = c.String(),
                        attachedFileAndPic = c.Int(nullable: false),
                        MaxLevelForContributions = c.String(),
                        ImgURL = c.String(maxLength: 2048),
                        LandNo = c.String(),
                        nots = c.String(maxLength: 2048),
                        MainLandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.MainLand", t => t.MainLandId)
                .Index(t => t.MainLandId);
            
            CreateTable(
                "dbo.OrderJobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderJobCode = c.String(),
                        contractorId = c.Int(),
                        SupervisorEngenneringId = c.Int(),
                        receiptEngenneringId = c.Int(),
                        MainProjectId = c.Int(),
                        ProjectsId = c.Int(),
                        SpecialNote = c.String(),
                        Note = c.String(),
                        IsCreateContract = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Engennering_id = c.Int(),
                        Engennering_id1 = c.Int(),
                        Engennering1_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.contractors", t => t.contractorId)
                .ForeignKey("dbo.Engennering", t => t.Engennering_id)
                .ForeignKey("dbo.Engennering", t => t.Engennering_id1)
                .ForeignKey("dbo.Engennering", t => t.Engennering1_id)
                .ForeignKey("dbo.MainProject", t => t.MainProjectId)
                .ForeignKey("dbo.Project", t => t.ProjectsId)
                .Index(t => t.contractorId)
                .Index(t => t.MainProjectId)
                .Index(t => t.ProjectsId)
                .Index(t => t.Engennering_id)
                .Index(t => t.Engennering_id1)
                .Index(t => t.Engennering1_id);
            
            CreateTable(
                "dbo.Engennering",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Aname = c.String(nullable: false, maxLength: 50),
                        Ename = c.String(),
                        Type = c.String(),
                        ResEmp = c.String(),
                        tele1 = c.String(),
                        Tele2 = c.String(),
                        Adress = c.String(),
                        LikeNo = c.Int(nullable: false),
                        EngCV = c.String(),
                        limitation = c.String(),
                        limitationTime = c.String(),
                        CrruntyCompletionRate = c.String(),
                        imgLogo = c.String(),
                        BankAccount1Name = c.String(),
                        BankAccount1 = c.String(),
                        BankAccountName2 = c.String(),
                        BankAccount2 = c.String(),
                        BankAccountName3 = c.String(),
                        BankAccount3 = c.String(),
                        nots = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.EngSupProes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectsId = c.Int(nullable: false),
                        SupplieresId = c.Int(nullable: false),
                        EngenneringId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Engennering", t => t.EngenneringId)
                .ForeignKey("dbo.Project", t => t.ProjectsId)
                .ForeignKey("dbo.Supplieres", t => t.SupplieresId)
                .Index(t => t.ProjectsId)
                .Index(t => t.SupplieresId)
                .Index(t => t.EngenneringId);
            
            CreateTable(
                "dbo.Supplieres",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Aname = c.String(nullable: false, maxLength: 50),
                        Ename = c.String(),
                        Type = c.String(),
                        ResEmp = c.String(),
                        tele1 = c.String(),
                        Tele2 = c.String(),
                        Adress = c.String(),
                        LikeNo = c.Int(nullable: false),
                        CompanyCV = c.String(),
                        limitation = c.String(),
                        limitationTime = c.String(),
                        CrruntyCompletionRate = c.String(),
                        imgLogo = c.String(),
                        BankAccount1Name = c.String(),
                        BankAccount1 = c.String(),
                        BankAccountName2 = c.String(),
                        BankAccount2 = c.String(),
                        BankAccountName3 = c.String(),
                        BankAccount3 = c.String(),
                        nots = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderJobDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderJobId = c.Int(),
                        StageId = c.Int(),
                        MainItemDetailId = c.Int(),
                        Cost = c.Decimal(precision: 18, scale: 2),
                        BeginDateAcutely = c.DateTime(),
                        BeginDateExpected = c.DateTime(),
                        EndDateAcutely = c.DateTime(),
                        EndDateExpected = c.DateTime(),
                        ExecutionTime = c.Int(),
                        Note = c.String(),
                        IsDeleted = c.Boolean(),
                        CompletionRate = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MainItemDetails", t => t.MainItemDetailId)
                .ForeignKey("dbo.OrderJobs", t => t.OrderJobId)
                .ForeignKey("dbo.StageMasters", t => t.StageId)
                .Index(t => t.OrderJobId)
                .Index(t => t.StageId)
                .Index(t => t.MainItemDetailId);
            
            CreateTable(
                "dbo.MainItemDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cost = c.String(),
                        Duration = c.String(),
                        MainItemID = c.Int(nullable: false),
                        StageMasterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MianItems", t => t.MainItemID)
                .ForeignKey("dbo.StageMasters", t => t.StageMasterID)
                .Index(t => t.MainItemID)
                .Index(t => t.StageMasterID);
            
            CreateTable(
                "dbo.StageMasters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Cost = c.String(),
                        Duration = c.String(),
                        StageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Stage", t => t.StageId)
                .Index(t => t.StageId);
            
            CreateTable(
                "dbo.Street",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aname = c.String(nullable: false, maxLength: 50),
                        Ename = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LKCountries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ARName = c.String(),
                        ENName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        HashCol = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustPaperReceipts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        customerId = c.Int(nullable: false),
                        paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        notes = c.String(),
                        refType = c.String(),
                        refID = c.Int(nullable: false),
                        paidMethod = c.String(),
                        salesManId = c.Int(nullable: false),
                        indate = c.DateTime(nullable: false),
                        empId = c.Int(nullable: false),
                        hashCol = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                        billId = c.Int(nullable: false),
                        Employee_Id = c.Int(),
                        Employee_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.customerId)
                .ForeignKey("dbo.Employees", t => t.empId)
                .ForeignKey("dbo.Employees", t => t.salesManId)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id1)
                .Index(t => t.customerId)
                .Index(t => t.salesManId)
                .Index(t => t.empId)
                .Index(t => t.Employee_Id)
                .Index(t => t.Employee_Id1);
            
            CreateTable(
                "dbo.EmloyeeTargets",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        salesManId = c.Int(nullable: false),
                        typeOfCommission = c.String(),
                        fromMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        toMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        precent = c.Double(nullable: false),
                        hashCol = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                        ItmId = c.Int(nullable: false),
                        typeOfOperation = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Employees", t => t.salesManId)
                .Index(t => t.salesManId);
            
            CreateTable(
                "dbo.EmployeeAttaches",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        attachFile = c.Binary(),
                        AttachPath = c.String(),
                        FileName = c.String(),
                        EmpId = c.Int(nullable: false),
                        hashcol = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Employees", t => t.EmpId)
                .Index(t => t.EmpId);
            
            CreateTable(
                "dbo.LKBranches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ARName = c.String(),
                        ENName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        HashCol = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LKNationalities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ARName = c.String(),
                        ENName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        HashCol = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LKTitles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ARName = c.String(),
                        ENName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        HashCol = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentSystems",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ARName = c.String(),
                        ENName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Villa",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Aname = c.String(nullable: false, maxLength: 50),
                        Ename = c.String(),
                        code = c.String(),
                        FlotSize = c.Int(nullable: false),
                        BeginDateAcutely = c.DateTime(nullable: false),
                        BeginDateExpected = c.DateTime(nullable: false),
                        EndDateAcutely = c.DateTime(nullable: false),
                        EndDateExpected = c.DateTime(nullable: false),
                        ImgUrl = c.String(),
                        AttachedId = c.String(),
                        BedroomNo = c.Int(nullable: false),
                        resptionNo = c.Int(nullable: false),
                        Nots = c.String(),
                        ProjectId = c.Int(nullable: false),
                        DegreeOfExcellenceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.DegreeOfExcellence", t => t.DegreeOfExcellenceId)
                .ForeignKey("dbo.Project", t => t.ProjectId)
                .Index(t => t.ProjectId)
                .Index(t => t.DegreeOfExcellenceId);
            
            CreateTable(
                "dbo.ProjectsAttachments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        ProjectsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Project", t => t.ProjectsId)
                .Index(t => t.ProjectsId);
            
            CreateTable(
                "dbo.BillPurchasesDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ConstructionMaterialId = c.Int(),
                        billId = c.Int(),
                        Qu = c.Int(),
                        price = c.Decimal(precision: 18, scale: 2),
                        rowTotal = c.Decimal(precision: 18, scale: 2),
                        disPer = c.Double(),
                        disNo = c.Decimal(precision: 18, scale: 2),
                        hashCol = c.String(),
                        isDeleted = c.Boolean(),
                        tax = c.Decimal(precision: 18, scale: 2),
                        STOREID = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.BillPurchasesMasters", t => t.billId)
                .ForeignKey("dbo.ConstructionMaterials", t => t.ConstructionMaterialId)
                .ForeignKey("dbo.LKStores", t => t.STOREID)
                .Index(t => t.ConstructionMaterialId)
                .Index(t => t.billId)
                .Index(t => t.STOREID);
            
            CreateTable(
                "dbo.BillPurchasesMasters",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        empID = c.Int(),
                        customersId = c.Int(),
                        salesManId = c.Int(),
                        addDate = c.DateTime(),
                        refNo = c.String(),
                        refType = c.String(),
                        billType = c.String(),
                        paidType = c.String(),
                        total = c.Decimal(precision: 18, scale: 2),
                        disMoney = c.Decimal(precision: 18, scale: 2),
                        disPer = c.Double(),
                        paid = c.Decimal(precision: 18, scale: 2),
                        net = c.Decimal(precision: 18, scale: 2),
                        isApproval = c.Boolean(nullable: false),
                        hashCol = c.String(),
                        isDeleted = c.Boolean(),
                        tax = c.Decimal(precision: 18, scale: 2),
                        Employee_Id = c.Int(),
                        Employee1_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.customersId)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Employees", t => t.Employee1_Id)
                .Index(t => t.customersId)
                .Index(t => t.Employee_Id)
                .Index(t => t.Employee1_Id);
            
            CreateTable(
                "dbo.LKStores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ARName = c.String(),
                        ENName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        HashCol = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CashReceiptFromShareholders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Cost = c.String(),
                        Date = c.DateTime(nullable: false),
                        Guiding = c.Boolean(nullable: false),
                        Statement = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ContributerPaymentForProjects",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ContributorId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Actuallypaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        notes = c.String(),
                        salesManId = c.Int(nullable: false),
                        indate = c.DateTime(nullable: false),
                        empId = c.Int(nullable: false),
                        paidMethod = c.String(),
                        salesManName = c.String(),
                        payType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.EngineerReceiveFromContractors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WorkOrderNumber = c.String(),
                        ContractorNumber = c.String(),
                        Specifications = c.String(),
                        Notes = c.String(),
                        Identical = c.Boolean(nullable: false),
                        CompletionRate = c.String(),
                        Finished = c.Boolean(nullable: false),
                        ReceiptNotes = c.String(),
                        Recommendations = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aname = c.String(nullable: false, maxLength: 50),
                        Ename = c.String(),
                        NoOfDaies = c.Int(nullable: false),
                        Description = c.String(),
                        AttachedId = c.String(),
                        DegreeOfExcellenceId = c.Int(nullable: false),
                        HaveItem = c.Boolean(nullable: false),
                        Nots = c.String(),
                        UnitsId = c.Int(nullable: false),
                        Long = c.Single(nullable: false),
                        width = c.Single(nullable: false),
                        price = c.Single(nullable: false),
                        brand = c.String(),
                        types = c.String(),
                        RelatedWithSuppelyId = c.Int(nullable: false),
                        StageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stage", t => t.StageId)
                .Index(t => t.StageId);
            
            CreateTable(
                "dbo.units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aname = c.String(nullable: false, maxLength: 50),
                        Ename = c.String(),
                        RelatedWithUniteNo = c.Int(nullable: false),
                        RateOfTrans = c.Single(nullable: false),
                        IsTransation = c.Boolean(nullable: false),
                        ItemsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemsId)
                .Index(t => t.ItemsId);
            
            CreateTable(
                "dbo.MainProjectAttachments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        MainProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MainProject", t => t.MainProjectId)
                .Index(t => t.MainProjectId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MessageContent = c.String(nullable: false),
                        Seen = c.Boolean(nullable: false),
                        SenderId = c.String(),
                        ReceiverId = c.String(),
                        SenderUsername = c.String(),
                        ReceiverUsername = c.String(),
                        SentAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LKPaymentMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        ARName = c.String(),
                        ENName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        HashCol = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PricesOffersDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ConstructionMaterialId = c.Int(),
                        billId = c.Int(),
                        Qu = c.Int(),
                        price = c.Decimal(precision: 18, scale: 2),
                        rowTotal = c.Decimal(precision: 18, scale: 2),
                        disPer = c.Double(),
                        disNo = c.Decimal(precision: 18, scale: 2),
                        hashCol = c.String(),
                        isDeleted = c.Boolean(),
                        tax = c.Decimal(precision: 18, scale: 2),
                        STOREID = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ConstructionMaterials", t => t.ConstructionMaterialId)
                .ForeignKey("dbo.LKStores", t => t.STOREID)
                .ForeignKey("dbo.PricesOffersMasters", t => t.billId)
                .Index(t => t.ConstructionMaterialId)
                .Index(t => t.billId)
                .Index(t => t.STOREID);
            
            CreateTable(
                "dbo.PricesOffersMasters",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        empID = c.Int(),
                        customersId = c.Int(),
                        salesManId = c.Int(),
                        addDate = c.DateTime(),
                        refNo = c.String(),
                        refType = c.String(),
                        billType = c.String(),
                        paidType = c.String(),
                        total = c.Decimal(precision: 18, scale: 2),
                        disMoney = c.Decimal(precision: 18, scale: 2),
                        disPer = c.Double(),
                        paid = c.Decimal(precision: 18, scale: 2),
                        net = c.Decimal(precision: 18, scale: 2),
                        isApproval = c.Boolean(nullable: false),
                        hashCol = c.String(),
                        isDeleted = c.Boolean(),
                        tax = c.Decimal(precision: 18, scale: 2),
                        Employee_Id = c.Int(),
                        Employee1_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.customersId)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Employees", t => t.Employee1_Id)
                .Index(t => t.customersId)
                .Index(t => t.Employee_Id)
                .Index(t => t.Employee1_Id);
            
            CreateTable(
                "dbo.ProjectStatu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aname = c.String(nullable: false, maxLength: 50),
                        Ename = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectTextDescription",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aname = c.String(nullable: false, maxLength: 50),
                        Ename = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Shareholders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ShareholderName = c.String(),
                        Address = c.String(),
                        BankAccount = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StoreTransactions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        storied = c.Int(),
                        IndexId = c.Int(),
                        ConstructionMaterialId = c.Int(),
                        ISadd = c.Boolean(),
                        Quan = c.Int(),
                        unitId = c.Int(),
                        Refid = c.String(),
                        refType = c.String(),
                        hashCol = c.String(),
                        isDeleted = c.Boolean(),
                        notes = c.String(),
                        billId = c.Int(),
                        indate = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ConstructionMaterials", t => t.ConstructionMaterialId)
                .ForeignKey("dbo.LKStores", t => t.storied)
                .Index(t => t.storied)
                .Index(t => t.ConstructionMaterialId);
            
            CreateTable(
                "dbo.TypesInvestment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aname = c.String(nullable: false, maxLength: 250),
                        Ename = c.String(),
                        Nots = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.VillaAttachments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        VillaId = c.Int(nullable: false),
                        VillaAttachment_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.VillaAttachments", t => t.VillaAttachment_ID)
                .ForeignKey("dbo.Villa", t => t.VillaId)
                .Index(t => t.VillaId)
                .Index(t => t.VillaAttachment_ID);
            
            CreateTable(
                "dbo.WarehouseWarrantDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ConstructionMaterialId = c.Int(),
                        billId = c.Int(),
                        Qu = c.Int(),
                        price = c.Decimal(precision: 18, scale: 2),
                        rowTotal = c.Decimal(precision: 18, scale: 2),
                        hashCol = c.String(),
                        isDeleted = c.Boolean(),
                        STOREID = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ConstructionMaterials", t => t.ConstructionMaterialId)
                .ForeignKey("dbo.LKStores", t => t.STOREID)
                .ForeignKey("dbo.WarehouseWarrantMasters", t => t.billId)
                .Index(t => t.ConstructionMaterialId)
                .Index(t => t.billId)
                .Index(t => t.STOREID);
            
            CreateTable(
                "dbo.WarehouseWarrantMasters",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        empID = c.Int(),
                        contractorId = c.Int(),
                        EngenneringId = c.Int(),
                        addDate = c.DateTime(),
                        refNo = c.String(),
                        refType = c.String(),
                        total = c.Decimal(precision: 18, scale: 2),
                        hashCol = c.String(),
                        isDeleted = c.Boolean(),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.contractors", t => t.contractorId)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Engennering", t => t.EngenneringId)
                .Index(t => t.contractorId)
                .Index(t => t.EngenneringId)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WarehouseWarrantDetails", "billId", "dbo.WarehouseWarrantMasters");
            DropForeignKey("dbo.WarehouseWarrantMasters", "EngenneringId", "dbo.Engennering");
            DropForeignKey("dbo.WarehouseWarrantMasters", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.WarehouseWarrantMasters", "contractorId", "dbo.contractors");
            DropForeignKey("dbo.WarehouseWarrantDetails", "STOREID", "dbo.LKStores");
            DropForeignKey("dbo.WarehouseWarrantDetails", "ConstructionMaterialId", "dbo.ConstructionMaterials");
            DropForeignKey("dbo.VillaAttachments", "VillaId", "dbo.Villa");
            DropForeignKey("dbo.VillaAttachments", "VillaAttachment_ID", "dbo.VillaAttachments");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StoreTransactions", "storied", "dbo.LKStores");
            DropForeignKey("dbo.StoreTransactions", "ConstructionMaterialId", "dbo.ConstructionMaterials");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PricesOffersDetails", "billId", "dbo.PricesOffersMasters");
            DropForeignKey("dbo.PricesOffersMasters", "Employee1_Id", "dbo.Employees");
            DropForeignKey("dbo.PricesOffersMasters", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.PricesOffersMasters", "customersId", "dbo.Customers");
            DropForeignKey("dbo.PricesOffersDetails", "STOREID", "dbo.LKStores");
            DropForeignKey("dbo.PricesOffersDetails", "ConstructionMaterialId", "dbo.ConstructionMaterials");
            DropForeignKey("dbo.MainProjectAttachments", "MainProjectId", "dbo.MainProject");
            DropForeignKey("dbo.units", "ItemsId", "dbo.Items");
            DropForeignKey("dbo.Items", "StageId", "dbo.Stage");
            DropForeignKey("dbo.BillPurchasesDetails", "STOREID", "dbo.LKStores");
            DropForeignKey("dbo.BillPurchasesDetails", "ConstructionMaterialId", "dbo.ConstructionMaterials");
            DropForeignKey("dbo.BillPurchasesDetails", "billId", "dbo.BillPurchasesMasters");
            DropForeignKey("dbo.BillPurchasesMasters", "Employee1_Id", "dbo.Employees");
            DropForeignKey("dbo.BillPurchasesMasters", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.BillPurchasesMasters", "customersId", "dbo.Customers");
            DropForeignKey("dbo.Stage", "MianItems_Id", "dbo.MianItems");
            DropForeignKey("dbo.ProjectStages", "StageID", "dbo.Stage");
            DropForeignKey("dbo.ProjectStages", "ProjectID", "dbo.Project");
            DropForeignKey("dbo.ProjectsAttachments", "ProjectsId", "dbo.Project");
            DropForeignKey("dbo.EmployeeSales", "VillaId", "dbo.Villa");
            DropForeignKey("dbo.Villa", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.EmployeeSales", "Villa_id", "dbo.Villa");
            DropForeignKey("dbo.Villa", "DegreeOfExcellenceId", "dbo.DegreeOfExcellence");
            DropForeignKey("dbo.EmployeeSales", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.EmployeeSales", "PaymentSystemId", "dbo.PaymentSystems");
            DropForeignKey("dbo.EmployeeSales", "FlatId", "dbo.Flat");
            DropForeignKey("dbo.EmployeeSales", "CustId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "LKCityId", "dbo.City");
            DropForeignKey("dbo.Customers", "AccountId", "dbo.LKAccounts");
            DropForeignKey("dbo.CustomerSelectFlats", "FlatId", "dbo.Flat");
            DropForeignKey("dbo.CustomerSelectFlats", "CustPaperPayment_id", "dbo.CustPaperPayments");
            DropForeignKey("dbo.CustPaperPayments", "salesManId", "dbo.Employees");
            DropForeignKey("dbo.CustPaperPayments", "empId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "TitleId", "dbo.LKTitles");
            DropForeignKey("dbo.Employees", "LKNationalityId", "dbo.LKNationalities");
            DropForeignKey("dbo.Employees", "LKBranchId", "dbo.LKBranches");
            DropForeignKey("dbo.EmployeeSales", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.EmployeeAttaches", "EmpId", "dbo.Employees");
            DropForeignKey("dbo.EmloyeeTargets", "salesManId", "dbo.Employees");
            DropForeignKey("dbo.CustPaperReceipts", "Employee_Id1", "dbo.Employees");
            DropForeignKey("dbo.CustPaperReceipts", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.CustPaperReceipts", "salesManId", "dbo.Employees");
            DropForeignKey("dbo.CustPaperReceipts", "empId", "dbo.Employees");
            DropForeignKey("dbo.CustPaperReceipts", "customerId", "dbo.Customers");
            DropForeignKey("dbo.CustPaperPayments", "Employee_Id1", "dbo.Employees");
            DropForeignKey("dbo.CustPaperPayments", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.contractorPaperReceipts", "Employee_Id1", "dbo.Employees");
            DropForeignKey("dbo.contractorPaperReceipts", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.contractorPaperPayments", "Employee_Id1", "dbo.Employees");
            DropForeignKey("dbo.contractorPaperPayments", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.contractorPaperPayments", "salesManId", "dbo.Employees");
            DropForeignKey("dbo.contractorPaperPayments", "empId", "dbo.Employees");
            DropForeignKey("dbo.contractorPaperPayments", "contractorId", "dbo.contractors");
            DropForeignKey("dbo.contractors", "LKCountryId", "dbo.LKCountries");
            DropForeignKey("dbo.Customers", "LKCountryId", "dbo.LKCountries");
            DropForeignKey("dbo.contractors", "LKCityId", "dbo.City");
            DropForeignKey("dbo.MainLand", "StreetID", "dbo.Street");
            DropForeignKey("dbo.Project", "MainProjectId", "dbo.MainProject");
            DropForeignKey("dbo.OrderJobs", "ProjectsId", "dbo.Project");
            DropForeignKey("dbo.OrderJobDetails", "StageId", "dbo.StageMasters");
            DropForeignKey("dbo.OrderJobDetails", "OrderJobId", "dbo.OrderJobs");
            DropForeignKey("dbo.OrderJobDetails", "MainItemDetailId", "dbo.MainItemDetails");
            DropForeignKey("dbo.StageMasters", "StageId", "dbo.Stage");
            DropForeignKey("dbo.MainItemDetails", "StageMasterID", "dbo.StageMasters");
            DropForeignKey("dbo.MainItemDetails", "MainItemID", "dbo.MianItems");
            DropForeignKey("dbo.OrderJobs", "MainProjectId", "dbo.MainProject");
            DropForeignKey("dbo.OrderJobs", "Engennering1_id", "dbo.Engennering");
            DropForeignKey("dbo.OrderJobs", "Engennering_id1", "dbo.Engennering");
            DropForeignKey("dbo.OrderJobs", "Engennering_id", "dbo.Engennering");
            DropForeignKey("dbo.EngSupProes", "SupplieresId", "dbo.Supplieres");
            DropForeignKey("dbo.EngSupProes", "ProjectsId", "dbo.Project");
            DropForeignKey("dbo.EngSupProes", "EngenneringId", "dbo.Engennering");
            DropForeignKey("dbo.OrderJobs", "contractorId", "dbo.contractors");
            DropForeignKey("dbo.MainProject", "MainLandId", "dbo.MainLand");
            DropForeignKey("dbo.Flat", "MainProject_id", "dbo.MainProject");
            DropForeignKey("dbo.MainLandAttachments", "MainLandId", "dbo.MainLand");
            DropForeignKey("dbo.Flat", "MainLand_id", "dbo.MainLand");
            DropForeignKey("dbo.Flat", "ProjectsId", "dbo.Project");
            DropForeignKey("dbo.Flat", "FlatTypeId", "dbo.FlatType");
            DropForeignKey("dbo.FlatAttachments", "FlatId", "dbo.Flat");
            DropForeignKey("dbo.EmployeeSales", "Flat_id", "dbo.Flat");
            DropForeignKey("dbo.Flat", "DegreeOfExcellenceId", "dbo.DegreeOfExcellence");
            DropForeignKey("dbo.Flat", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.MainLand", "DistrictID", "dbo.District");
            DropForeignKey("dbo.MainLand", "CitiesID", "dbo.City");
            DropForeignKey("dbo.contractors", "AccountId", "dbo.LKAccounts");
            DropForeignKey("dbo.contractorPaperReceipts", "salesManId", "dbo.Employees");
            DropForeignKey("dbo.contractorPaperReceipts", "empId", "dbo.Employees");
            DropForeignKey("dbo.contractorPaperReceipts", "contractorId", "dbo.contractors");
            DropForeignKey("dbo.ContPaperReceipts", "Employee_Id2", "dbo.Employees");
            DropForeignKey("dbo.ContPaperReceipts", "Employee_Id1", "dbo.Employees");
            DropForeignKey("dbo.ContPaperPayments", "Employee_Id2", "dbo.Employees");
            DropForeignKey("dbo.ContPaperPayments", "Employee_Id1", "dbo.Employees");
            DropForeignKey("dbo.ContPaperPayments", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.ContPaperPayments", "Employee1_Id", "dbo.Employees");
            DropForeignKey("dbo.ContPaperPayments", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.ContPaperPayments", "ContributorId", "dbo.Contributors");
            DropForeignKey("dbo.ContPaperReceipts", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.ContPaperReceipts", "Employee1_Id", "dbo.Employees");
            DropForeignKey("dbo.ContPaperReceipts", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.ContPaperReceipts", "ContributorId", "dbo.Contributors");
            DropForeignKey("dbo.CustPaperPayments", "customerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerSelectFlats", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.MianItemsAttachments", "MianItemsId", "dbo.MianItems");
            DropForeignKey("dbo.MaterialDetails", "MianItemsId", "dbo.MianItems");
            DropForeignKey("dbo.MaterialDetails", "ConstructionMaterialId", "dbo.ConstructionMaterials");
            DropForeignKey("dbo.ConstructionMaterialPriceVariables", "ConstructionMaterialId", "dbo.ConstructionMaterials");
            DropForeignKey("dbo.Attachments", "ConstructionMaterialId", "dbo.ConstructionMaterials");
            DropForeignKey("dbo.amiraDetails", "MasterId", "dbo.amiraMasters");
            DropIndex("dbo.WarehouseWarrantMasters", new[] { "Employee_Id" });
            DropIndex("dbo.WarehouseWarrantMasters", new[] { "EngenneringId" });
            DropIndex("dbo.WarehouseWarrantMasters", new[] { "contractorId" });
            DropIndex("dbo.WarehouseWarrantDetails", new[] { "STOREID" });
            DropIndex("dbo.WarehouseWarrantDetails", new[] { "billId" });
            DropIndex("dbo.WarehouseWarrantDetails", new[] { "ConstructionMaterialId" });
            DropIndex("dbo.VillaAttachments", new[] { "VillaAttachment_ID" });
            DropIndex("dbo.VillaAttachments", new[] { "VillaId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.StoreTransactions", new[] { "ConstructionMaterialId" });
            DropIndex("dbo.StoreTransactions", new[] { "storied" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PricesOffersMasters", new[] { "Employee1_Id" });
            DropIndex("dbo.PricesOffersMasters", new[] { "Employee_Id" });
            DropIndex("dbo.PricesOffersMasters", new[] { "customersId" });
            DropIndex("dbo.PricesOffersDetails", new[] { "STOREID" });
            DropIndex("dbo.PricesOffersDetails", new[] { "billId" });
            DropIndex("dbo.PricesOffersDetails", new[] { "ConstructionMaterialId" });
            DropIndex("dbo.MainProjectAttachments", new[] { "MainProjectId" });
            DropIndex("dbo.units", new[] { "ItemsId" });
            DropIndex("dbo.Items", new[] { "StageId" });
            DropIndex("dbo.BillPurchasesMasters", new[] { "Employee1_Id" });
            DropIndex("dbo.BillPurchasesMasters", new[] { "Employee_Id" });
            DropIndex("dbo.BillPurchasesMasters", new[] { "customersId" });
            DropIndex("dbo.BillPurchasesDetails", new[] { "STOREID" });
            DropIndex("dbo.BillPurchasesDetails", new[] { "billId" });
            DropIndex("dbo.BillPurchasesDetails", new[] { "ConstructionMaterialId" });
            DropIndex("dbo.ProjectsAttachments", new[] { "ProjectsId" });
            DropIndex("dbo.Villa", new[] { "DegreeOfExcellenceId" });
            DropIndex("dbo.Villa", new[] { "ProjectId" });
            DropIndex("dbo.EmployeeAttaches", new[] { "EmpId" });
            DropIndex("dbo.EmloyeeTargets", new[] { "salesManId" });
            DropIndex("dbo.CustPaperReceipts", new[] { "Employee_Id1" });
            DropIndex("dbo.CustPaperReceipts", new[] { "Employee_Id" });
            DropIndex("dbo.CustPaperReceipts", new[] { "empId" });
            DropIndex("dbo.CustPaperReceipts", new[] { "salesManId" });
            DropIndex("dbo.CustPaperReceipts", new[] { "customerId" });
            DropIndex("dbo.StageMasters", new[] { "StageId" });
            DropIndex("dbo.MainItemDetails", new[] { "StageMasterID" });
            DropIndex("dbo.MainItemDetails", new[] { "MainItemID" });
            DropIndex("dbo.OrderJobDetails", new[] { "MainItemDetailId" });
            DropIndex("dbo.OrderJobDetails", new[] { "StageId" });
            DropIndex("dbo.OrderJobDetails", new[] { "OrderJobId" });
            DropIndex("dbo.EngSupProes", new[] { "EngenneringId" });
            DropIndex("dbo.EngSupProes", new[] { "SupplieresId" });
            DropIndex("dbo.EngSupProes", new[] { "ProjectsId" });
            DropIndex("dbo.OrderJobs", new[] { "Engennering1_id" });
            DropIndex("dbo.OrderJobs", new[] { "Engennering_id1" });
            DropIndex("dbo.OrderJobs", new[] { "Engennering_id" });
            DropIndex("dbo.OrderJobs", new[] { "ProjectsId" });
            DropIndex("dbo.OrderJobs", new[] { "MainProjectId" });
            DropIndex("dbo.OrderJobs", new[] { "contractorId" });
            DropIndex("dbo.MainProject", new[] { "MainLandId" });
            DropIndex("dbo.MainLandAttachments", new[] { "MainLandId" });
            DropIndex("dbo.FlatAttachments", new[] { "FlatId" });
            DropIndex("dbo.Flat", new[] { "MainProject_id" });
            DropIndex("dbo.Flat", new[] { "MainLand_id" });
            DropIndex("dbo.Flat", new[] { "DegreeOfExcellenceId" });
            DropIndex("dbo.Flat", new[] { "ProjectsId" });
            DropIndex("dbo.Flat", new[] { "BuildingId" });
            DropIndex("dbo.Flat", new[] { "FlatTypeId" });
            DropIndex("dbo.MainLand", new[] { "CitiesID" });
            DropIndex("dbo.MainLand", new[] { "DistrictID" });
            DropIndex("dbo.MainLand", new[] { "StreetID" });
            DropIndex("dbo.contractorPaperReceipts", new[] { "Employee_Id1" });
            DropIndex("dbo.contractorPaperReceipts", new[] { "Employee_Id" });
            DropIndex("dbo.contractorPaperReceipts", new[] { "empId" });
            DropIndex("dbo.contractorPaperReceipts", new[] { "salesManId" });
            DropIndex("dbo.contractorPaperReceipts", new[] { "contractorId" });
            DropIndex("dbo.contractors", new[] { "LKCityId" });
            DropIndex("dbo.contractors", new[] { "LKCountryId" });
            DropIndex("dbo.contractors", new[] { "AccountId" });
            DropIndex("dbo.contractorPaperPayments", new[] { "Employee_Id1" });
            DropIndex("dbo.contractorPaperPayments", new[] { "Employee_Id" });
            DropIndex("dbo.contractorPaperPayments", new[] { "empId" });
            DropIndex("dbo.contractorPaperPayments", new[] { "salesManId" });
            DropIndex("dbo.contractorPaperPayments", new[] { "contractorId" });
            DropIndex("dbo.ContPaperReceipts", new[] { "Employee_Id2" });
            DropIndex("dbo.ContPaperReceipts", new[] { "Employee_Id1" });
            DropIndex("dbo.ContPaperReceipts", new[] { "Employee1_Id" });
            DropIndex("dbo.ContPaperReceipts", new[] { "Employee_Id" });
            DropIndex("dbo.ContPaperReceipts", new[] { "ProjectId" });
            DropIndex("dbo.ContPaperReceipts", new[] { "ContributorId" });
            DropIndex("dbo.ContPaperPayments", new[] { "Employee_Id2" });
            DropIndex("dbo.ContPaperPayments", new[] { "Employee_Id1" });
            DropIndex("dbo.ContPaperPayments", new[] { "Employee1_Id" });
            DropIndex("dbo.ContPaperPayments", new[] { "Employee_Id" });
            DropIndex("dbo.ContPaperPayments", new[] { "ProjectId" });
            DropIndex("dbo.ContPaperPayments", new[] { "ContributorId" });
            DropIndex("dbo.Employees", new[] { "TitleId" });
            DropIndex("dbo.Employees", new[] { "LKBranchId" });
            DropIndex("dbo.Employees", new[] { "LKNationalityId" });
            DropIndex("dbo.CustPaperPayments", new[] { "Employee_Id1" });
            DropIndex("dbo.CustPaperPayments", new[] { "Employee_Id" });
            DropIndex("dbo.CustPaperPayments", new[] { "empId" });
            DropIndex("dbo.CustPaperPayments", new[] { "salesManId" });
            DropIndex("dbo.CustPaperPayments", new[] { "customerId" });
            DropIndex("dbo.CustomerSelectFlats", new[] { "CustPaperPayment_id" });
            DropIndex("dbo.CustomerSelectFlats", new[] { "FlatId" });
            DropIndex("dbo.CustomerSelectFlats", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "LKCityId" });
            DropIndex("dbo.Customers", new[] { "LKCountryId" });
            DropIndex("dbo.Customers", new[] { "AccountId" });
            DropIndex("dbo.EmployeeSales", new[] { "Villa_id" });
            DropIndex("dbo.EmployeeSales", new[] { "Employee_Id" });
            DropIndex("dbo.EmployeeSales", new[] { "Flat_id" });
            DropIndex("dbo.EmployeeSales", new[] { "PaymentSystemId" });
            DropIndex("dbo.EmployeeSales", new[] { "CustId" });
            DropIndex("dbo.EmployeeSales", new[] { "VillaId" });
            DropIndex("dbo.EmployeeSales", new[] { "FlatId" });
            DropIndex("dbo.EmployeeSales", new[] { "ProjectId" });
            DropIndex("dbo.Project", new[] { "MainProjectId" });
            DropIndex("dbo.ProjectStages", new[] { "StageID" });
            DropIndex("dbo.ProjectStages", new[] { "ProjectID" });
            DropIndex("dbo.Stage", new[] { "MianItems_Id" });
            DropIndex("dbo.MianItemsAttachments", new[] { "MianItemsId" });
            DropIndex("dbo.MaterialDetails", new[] { "MianItemsId" });
            DropIndex("dbo.MaterialDetails", new[] { "ConstructionMaterialId" });
            DropIndex("dbo.ConstructionMaterialPriceVariables", new[] { "ConstructionMaterialId" });
            DropIndex("dbo.Attachments", new[] { "ConstructionMaterialId" });
            DropIndex("dbo.amiraDetails", new[] { "MasterId" });
            DropTable("dbo.WarehouseWarrantMasters");
            DropTable("dbo.WarehouseWarrantDetails");
            DropTable("dbo.VillaAttachments");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TypesInvestment");
            DropTable("dbo.StoreTransactions");
            DropTable("dbo.Shareholders");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProjectTextDescription");
            DropTable("dbo.ProjectStatu");
            DropTable("dbo.PricesOffersMasters");
            DropTable("dbo.PricesOffersDetails");
            DropTable("dbo.LKPaymentMethods");
            DropTable("dbo.Messages");
            DropTable("dbo.MainProjectAttachments");
            DropTable("dbo.units");
            DropTable("dbo.Items");
            DropTable("dbo.EngineerReceiveFromContractors");
            DropTable("dbo.ContributerPaymentForProjects");
            DropTable("dbo.CashReceiptFromShareholders");
            DropTable("dbo.LKStores");
            DropTable("dbo.BillPurchasesMasters");
            DropTable("dbo.BillPurchasesDetails");
            DropTable("dbo.ProjectsAttachments");
            DropTable("dbo.Villa");
            DropTable("dbo.PaymentSystems");
            DropTable("dbo.LKTitles");
            DropTable("dbo.LKNationalities");
            DropTable("dbo.LKBranches");
            DropTable("dbo.EmployeeAttaches");
            DropTable("dbo.EmloyeeTargets");
            DropTable("dbo.CustPaperReceipts");
            DropTable("dbo.LKCountries");
            DropTable("dbo.Street");
            DropTable("dbo.StageMasters");
            DropTable("dbo.MainItemDetails");
            DropTable("dbo.OrderJobDetails");
            DropTable("dbo.Supplieres");
            DropTable("dbo.EngSupProes");
            DropTable("dbo.Engennering");
            DropTable("dbo.OrderJobs");
            DropTable("dbo.MainProject");
            DropTable("dbo.MainLandAttachments");
            DropTable("dbo.FlatType");
            DropTable("dbo.FlatAttachments");
            DropTable("dbo.DegreeOfExcellence");
            DropTable("dbo.Buildings");
            DropTable("dbo.Flat");
            DropTable("dbo.District");
            DropTable("dbo.MainLand");
            DropTable("dbo.City");
            DropTable("dbo.LKAccounts");
            DropTable("dbo.contractorPaperReceipts");
            DropTable("dbo.contractors");
            DropTable("dbo.contractorPaperPayments");
            DropTable("dbo.ContPaperReceipts");
            DropTable("dbo.Contributors");
            DropTable("dbo.ContPaperPayments");
            DropTable("dbo.Employees");
            DropTable("dbo.CustPaperPayments");
            DropTable("dbo.CustomerSelectFlats");
            DropTable("dbo.Customers");
            DropTable("dbo.EmployeeSales");
            DropTable("dbo.Project");
            DropTable("dbo.ProjectStages");
            DropTable("dbo.Stage");
            DropTable("dbo.MianItemsAttachments");
            DropTable("dbo.MianItems");
            DropTable("dbo.MaterialDetails");
            DropTable("dbo.ConstructionMaterialPriceVariables");
            DropTable("dbo.ConstructionMaterials");
            DropTable("dbo.Attachments");
            DropTable("dbo.AssignedSuppliers");
            DropTable("dbo.amiraMasters");
            DropTable("dbo.amiraDetails");
            DropTable("dbo.AdditionalSpecifications");
            DropTable("dbo.Abstracts");
        }
    }
}
