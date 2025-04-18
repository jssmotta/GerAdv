﻿"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { GruposEmpresasGridAdapter } from "@/app/GerAdv_TS/GruposEmpresas/Adapter/GruposEmpresasGridAdapter";
import GruposEmpresasGridContainer from "@/app/GerAdv_TS/GruposEmpresas/Components/GruposEmpresasGridContainer";

const GruposEmpresasPage: React.FC = () => {
    const GruposEmpresasGrid = new GruposEmpresasGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Grupos Empresas" />
            <GruposEmpresasGridContainer grid={GruposEmpresasGrid} />
        </PageLayout>
    );
};

export default GruposEmpresasPage;