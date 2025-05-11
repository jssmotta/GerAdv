"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { ProPartesGridAdapter } from "@/app/GerAdv_TS/ProPartes/Adapter/ProPartesGridAdapter";
import ProPartesGridContainer from "@/app/GerAdv_TS/ProPartes/Components/ProPartesGridContainer";

const ProPartesPage: React.FC = () => {
    const ProPartesGrid = new ProPartesGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Pro Partes" />
            <ProPartesGridContainer grid={ProPartesGrid} />
        </PageLayout>
    );
};

export default ProPartesPage;