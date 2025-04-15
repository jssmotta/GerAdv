"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { RegimeTributacaoGridAdapter } from "@/app/GerAdv_TS/RegimeTributacao/Adapter/RegimeTributacaoGridAdapter";
import RegimeTributacaoGridContainer from "@/app/GerAdv_TS/RegimeTributacao/Components/RegimeTributacaoGridContainer";

const RegimeTributacaoPage: React.FC = () => {
    const RegimeTributacaoGrid = new RegimeTributacaoGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Regime Tributacao" />
            <RegimeTributacaoGridContainer grid={RegimeTributacaoGrid} />
        </PageLayout>
    );
};

export default RegimeTributacaoPage;