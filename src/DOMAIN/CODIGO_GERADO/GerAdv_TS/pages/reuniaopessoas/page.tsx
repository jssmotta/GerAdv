"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { ReuniaoPessoasGridAdapter } from "@/app/GerAdv_TS/ReuniaoPessoas/Adapter/ReuniaoPessoasGridAdapter";
import ReuniaoPessoasGridContainer from "@/app/GerAdv_TS/ReuniaoPessoas/Components/ReuniaoPessoasGridContainer";

const ReuniaoPessoasPage: React.FC = () => {
    const ReuniaoPessoasGrid = new ReuniaoPessoasGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Reuniao Pessoas" />
            <ReuniaoPessoasGridContainer grid={ReuniaoPessoasGrid} />
        </PageLayout>
    );
};

export default ReuniaoPessoasPage;