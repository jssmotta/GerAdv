"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { SituacaoGridAdapter } from "@/app/GerAdv_TS/Situacao/Adapter/SituacaoGridAdapter";
import SituacaoGridContainer from "@/app/GerAdv_TS/Situacao/Components/SituacaoGridContainer";

const SituacaoPage: React.FC = () => {
    const SituacaoGrid = new SituacaoGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Situacao" />
            <SituacaoGridContainer grid={SituacaoGrid} />
        </PageLayout>
    );
};

export default SituacaoPage;