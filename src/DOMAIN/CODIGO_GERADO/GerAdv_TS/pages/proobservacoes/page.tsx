"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { ProObservacoesGridAdapter } from "@/app/GerAdv_TS/ProObservacoes/Adapter/ProObservacoesGridAdapter";
import ProObservacoesGridContainer from "@/app/GerAdv_TS/ProObservacoes/Components/ProObservacoesGridContainer";

const ProObservacoesPage: React.FC = () => {
    const ProObservacoesGrid = new ProObservacoesGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Pro Observacoes" />
            <ProObservacoesGridContainer grid={ProObservacoesGrid} />
        </PageLayout>
    );
};

export default ProObservacoesPage;