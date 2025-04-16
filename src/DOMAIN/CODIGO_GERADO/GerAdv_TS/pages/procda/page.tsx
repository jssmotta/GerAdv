"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { ProCDAGridAdapter } from "@/app/GerAdv_TS/ProCDA/Adapter/ProCDAGridAdapter";
import ProCDAGridContainer from "@/app/GerAdv_TS/ProCDA/Components/ProCDAGridContainer";

const ProCDAPage: React.FC = () => {
    const ProCDAGrid = new ProCDAGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Pro C D A" />
            <ProCDAGridContainer grid={ProCDAGrid} />
        </PageLayout>
    );
};

export default ProCDAPage;