"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { SetorGridAdapter } from "@/app/GerAdv_TS/Setor/Adapter/SetorGridAdapter";
import SetorGridContainer from "@/app/GerAdv_TS/Setor/Components/SetorGridContainer";

const SetorPage: React.FC = () => {
    const SetorGrid = new SetorGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Setor" />
            <SetorGridContainer grid={SetorGrid} />
        </PageLayout>
    );
};

export default SetorPage;