"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { ReuniaoGridAdapter } from "@/app/GerAdv_TS/Reuniao/Adapter/ReuniaoGridAdapter";
import ReuniaoGridContainer from "@/app/GerAdv_TS/Reuniao/Components/ReuniaoGridContainer";

const ReuniaoPage: React.FC = () => {
    const ReuniaoGrid = new ReuniaoGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Reuniao" />
            <ReuniaoGridContainer grid={ReuniaoGrid} />
        </PageLayout>
    );
};

export default ReuniaoPage;