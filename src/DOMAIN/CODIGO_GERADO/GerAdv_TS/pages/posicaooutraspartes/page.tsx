"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { PosicaoOutrasPartesGridAdapter } from "@/app/GerAdv_TS/PosicaoOutrasPartes/Adapter/PosicaoOutrasPartesGridAdapter";
import PosicaoOutrasPartesGridContainer from "@/app/GerAdv_TS/PosicaoOutrasPartes/Components/PosicaoOutrasPartesGridContainer";

const PosicaoOutrasPartesPage: React.FC = () => {
    const PosicaoOutrasPartesGrid = new PosicaoOutrasPartesGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Posicao Outras Partes" />
            <PosicaoOutrasPartesGridContainer grid={PosicaoOutrasPartesGrid} />
        </PageLayout>
    );
};

export default PosicaoOutrasPartesPage;