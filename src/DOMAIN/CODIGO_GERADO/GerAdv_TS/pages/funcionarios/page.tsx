﻿"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { FuncionariosGridAdapter } from "@/app/GerAdv_TS/Funcionarios/Adapter/FuncionariosGridAdapter";
import FuncionariosGridContainer from "@/app/GerAdv_TS/Funcionarios/Components/FuncionariosGridContainer";

const FuncionariosPage: React.FC = () => {
    const FuncionariosGrid = new FuncionariosGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Colaborador" />
            <FuncionariosGridContainer grid={FuncionariosGrid} />
        </PageLayout>
    );
};

export default FuncionariosPage;