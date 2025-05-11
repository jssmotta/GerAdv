"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { ProProcuradoresGridAdapter } from "@/app/GerAdv_TS/ProProcuradores/Adapter/ProProcuradoresGridAdapter";
import ProProcuradoresGridContainer from "@/app/GerAdv_TS/ProProcuradores/Components/ProProcuradoresGridContainer";

const ProProcuradoresPage: React.FC = () => {
    const ProProcuradoresGrid = new ProProcuradoresGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Pro Procuradores" />
            <ProProcuradoresGridContainer grid={ProProcuradoresGrid} />
        </PageLayout>
    );
};

export default ProProcuradoresPage;