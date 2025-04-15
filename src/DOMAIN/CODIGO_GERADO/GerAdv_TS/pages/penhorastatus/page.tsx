"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { PenhoraStatusGridAdapter } from "@/app/GerAdv_TS/PenhoraStatus/Adapter/PenhoraStatusGridAdapter";
import PenhoraStatusGridContainer from "@/app/GerAdv_TS/PenhoraStatus/Components/PenhoraStatusGridContainer";

const PenhoraStatusPage: React.FC = () => {
    const PenhoraStatusGrid = new PenhoraStatusGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Penhora Status" />
            <PenhoraStatusGridContainer grid={PenhoraStatusGrid} />
        </PageLayout>
    );
};

export default PenhoraStatusPage;