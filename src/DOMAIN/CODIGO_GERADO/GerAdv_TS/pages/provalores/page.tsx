"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { ProValoresGridAdapter } from "@/app/GerAdv_TS/ProValores/Adapter/ProValoresGridAdapter";
import ProValoresGridContainer from "@/app/GerAdv_TS/ProValores/Components/ProValoresGridContainer";

const ProValoresPage: React.FC = () => {
    const ProValoresGrid = new ProValoresGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Pro Valores" />
            <ProValoresGridContainer grid={ProValoresGrid} />
        </PageLayout>
    );
};

export default ProValoresPage;