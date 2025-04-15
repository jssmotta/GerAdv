"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { NEPalavrasChavesGridAdapter } from "@/app/GerAdv_TS/NEPalavrasChaves/Adapter/NEPalavrasChavesGridAdapter";
import NEPalavrasChavesGridContainer from "@/app/GerAdv_TS/NEPalavrasChaves/Components/NEPalavrasChavesGridContainer";

const NEPalavrasChavesPage: React.FC = () => {
    const NEPalavrasChavesGrid = new NEPalavrasChavesGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="N E Palavras Chaves" />
            <NEPalavrasChavesGridContainer grid={NEPalavrasChavesGrid} />
        </PageLayout>
    );
};

export default NEPalavrasChavesPage;