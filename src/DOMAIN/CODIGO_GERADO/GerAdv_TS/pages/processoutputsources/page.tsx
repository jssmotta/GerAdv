"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { ProcessOutputSourcesGridAdapter } from "@/app/GerAdv_TS/ProcessOutputSources/Adapter/ProcessOutputSourcesGridAdapter";
import ProcessOutputSourcesGridContainer from "@/app/GerAdv_TS/ProcessOutputSources/Components/ProcessOutputSourcesGridContainer";

const ProcessOutputSourcesPage: React.FC = () => {
    const ProcessOutputSourcesGrid = new ProcessOutputSourcesGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Process Output Sources" />
            <ProcessOutputSourcesGridContainer grid={ProcessOutputSourcesGrid} />
        </PageLayout>
    );
};

export default ProcessOutputSourcesPage;