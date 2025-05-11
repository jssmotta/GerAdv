"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { ViaRecebimentoGridAdapter } from "@/app/GerAdv_TS/ViaRecebimento/Adapter/ViaRecebimentoGridAdapter";
import ViaRecebimentoGridContainer from "@/app/GerAdv_TS/ViaRecebimento/Components/ViaRecebimentoGridContainer";

const ViaRecebimentoPage: React.FC = () => {
    const ViaRecebimentoGrid = new ViaRecebimentoGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Via Recebimento" />
            <ViaRecebimentoGridContainer grid={ViaRecebimentoGrid} />
        </PageLayout>
    );
};

export default ViaRecebimentoPage;