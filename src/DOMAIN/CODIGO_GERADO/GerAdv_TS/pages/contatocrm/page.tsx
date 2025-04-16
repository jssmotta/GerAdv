"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { ContatoCRMGridAdapter } from "@/app/GerAdv_TS/ContatoCRM/Adapter/ContatoCRMGridAdapter";
import ContatoCRMGridContainer from "@/app/GerAdv_TS/ContatoCRM/Components/ContatoCRMGridContainer";

const ContatoCRMPage: React.FC = () => {
    const ContatoCRMGrid = new ContatoCRMGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Contato C R M" />
            <ContatoCRMGridContainer grid={ContatoCRMGrid} />
        </PageLayout>
    );
};

export default ContatoCRMPage;