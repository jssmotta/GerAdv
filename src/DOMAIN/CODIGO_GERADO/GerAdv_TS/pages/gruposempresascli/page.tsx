﻿"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { GruposEmpresasCliGridAdapter } from "@/app/GerAdv_TS/GruposEmpresasCli/Adapter/GruposEmpresasCliGridAdapter";
import GruposEmpresasCliGridContainer from "@/app/GerAdv_TS/GruposEmpresasCli/Components/GruposEmpresasCliGridContainer";

const GruposEmpresasCliPage: React.FC = () => {
    const GruposEmpresasCliGrid = new GruposEmpresasCliGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Grupos Empresas Cli" />
            <GruposEmpresasCliGridContainer grid={GruposEmpresasCliGrid} />
        </PageLayout>
    );
};

export default GruposEmpresasCliPage;