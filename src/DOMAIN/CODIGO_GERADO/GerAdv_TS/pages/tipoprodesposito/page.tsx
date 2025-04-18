﻿"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { TipoProDespositoGridAdapter } from "@/app/GerAdv_TS/TipoProDesposito/Adapter/TipoProDespositoGridAdapter";
import TipoProDespositoGridContainer from "@/app/GerAdv_TS/TipoProDesposito/Components/TipoProDespositoGridContainer";

const TipoProDespositoPage: React.FC = () => {
    const TipoProDespositoGrid = new TipoProDespositoGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Tipo Pro Desposito" />
            <TipoProDespositoGridContainer grid={TipoProDespositoGrid} />
        </PageLayout>
    );
};

export default TipoProDespositoPage;