"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { RamalGridAdapter } from "@/app/GerAdv_TS/Ramal/Adapter/RamalGridAdapter";
import RamalGridContainer from "@/app/GerAdv_TS/Ramal/Components/RamalGridContainer";

const RamalPage: React.FC = () => {
    const RamalGrid = new RamalGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Ramal" />
            <RamalGridContainer grid={RamalGrid} />
        </PageLayout>
    );
};

export default RamalPage;