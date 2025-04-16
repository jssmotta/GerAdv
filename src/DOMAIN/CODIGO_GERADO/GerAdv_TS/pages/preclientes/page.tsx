"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { PreClientesGridAdapter } from "@/app/GerAdv_TS/PreClientes/Adapter/PreClientesGridAdapter";
import PreClientesGridContainer from "@/app/GerAdv_TS/PreClientes/Components/PreClientesGridContainer";

const PreClientesPage: React.FC = () => {
    const PreClientesGrid = new PreClientesGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Pre Clientes" />
            <PreClientesGridContainer grid={PreClientesGrid} />
        </PageLayout>
    );
};

export default PreClientesPage;