"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { UFGridAdapter } from "@/app/GerAdv_TS/UF/Adapter/UFGridAdapter";
import UFGridContainer from "@/app/GerAdv_TS/UF/Components/UFGridContainer";

const UFPage: React.FC = () => {
    const UFGrid = new UFGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="UF" />
            <UFGridContainer grid={UFGrid} />
        </PageLayout>
    );
};

export default UFPage;