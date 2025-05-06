"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { GUTPeriodicidadeStatusGridAdapter } from "@/app/GerAdv_TS/GUTPeriodicidadeStatus/Adapter/GUTPeriodicidadeStatusGridAdapter";
import GUTPeriodicidadeStatusGridContainer from "@/app/GerAdv_TS/GUTPeriodicidadeStatus/Components/GUTPeriodicidadeStatusGridContainer";

const GUTPeriodicidadeStatusPage: React.FC = () => {
    const GUTPeriodicidadeStatusGrid = new GUTPeriodicidadeStatusGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="G U T Periodicidade Status" />
            <GUTPeriodicidadeStatusGridContainer grid={GUTPeriodicidadeStatusGrid} />
        </PageLayout>
    );
};

export default GUTPeriodicidadeStatusPage;