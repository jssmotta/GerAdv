"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { ProcessOutputRequestGridAdapter } from "@/app/GerAdv_TS/ProcessOutputRequest/Adapter/ProcessOutputRequestGridAdapter";
import ProcessOutputRequestGridContainer from "@/app/GerAdv_TS/ProcessOutputRequest/Components/ProcessOutputRequestGridContainer";

const ProcessOutputRequestPage: React.FC = () => {
    const ProcessOutputRequestGrid = new ProcessOutputRequestGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Process Output Request" />
            <ProcessOutputRequestGridContainer grid={ProcessOutputRequestGrid} />
        </PageLayout>
    );
};

export default ProcessOutputRequestPage;