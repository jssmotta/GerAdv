"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { ProDespesasGridAdapter } from "@/app/GerAdv_TS/ProDespesas/Adapter/ProDespesasGridAdapter";
import ProDespesasGridContainer from "@/app/GerAdv_TS/ProDespesas/Components/ProDespesasGridContainer";

const ProDespesasPage: React.FC = () => {
    const ProDespesasGrid = new ProDespesasGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Pro Despesas" />
            <ProDespesasGridContainer grid={ProDespesasGrid} />
        </PageLayout>
    );
};

export default ProDespesasPage;