﻿"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { FornecedoresGridAdapter } from "@/app/GerAdv_TS/Fornecedores/Adapter/FornecedoresGridAdapter";
import FornecedoresGridContainer from "@/app/GerAdv_TS/Fornecedores/Components/FornecedoresGridContainer";

const FornecedoresPage: React.FC = () => {
    const FornecedoresGrid = new FornecedoresGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Fornecedores" />
            <FornecedoresGridContainer grid={FornecedoresGrid} />
        </PageLayout>
    );
};

export default FornecedoresPage;