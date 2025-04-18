﻿"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { Auditor4KGridAdapter } from "@/app/GerAdv_TS/Auditor4K/Adapter/Auditor4KGridAdapter";
import Auditor4KGridContainer from "@/app/GerAdv_TS/Auditor4K/Components/Auditor4KGridContainer";

const Auditor4KPage: React.FC = () => {
    const Auditor4KGrid = new Auditor4KGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Auditor4 K" />
            <Auditor4KGridContainer grid={Auditor4KGrid} />
        </PageLayout>
    );
};

export default Auditor4KPage;