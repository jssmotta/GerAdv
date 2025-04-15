"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { ContatoCRMViewGridAdapter } from "@/app/GerAdv_TS/ContatoCRMView/Adapter/ContatoCRMViewGridAdapter";
import ContatoCRMViewGridContainer from "@/app/GerAdv_TS/ContatoCRMView/Components/ContatoCRMViewGridContainer";

const ContatoCRMViewPage: React.FC = () => {
    const ContatoCRMViewGrid = new ContatoCRMViewGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Contato C R M View" />
            <ContatoCRMViewGridContainer grid={ContatoCRMViewGrid} />
        </PageLayout>
    );
};

export default ContatoCRMViewPage;