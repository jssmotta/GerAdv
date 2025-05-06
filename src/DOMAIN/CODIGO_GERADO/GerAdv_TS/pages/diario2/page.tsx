"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { Diario2GridAdapter } from "@/app/GerAdv_TS/Diario2/Adapter/Diario2GridAdapter";
import Diario2GridContainer from "@/app/GerAdv_TS/Diario2/Components/Diario2GridContainer";

const Diario2Page: React.FC = () => {
    const Diario2Grid = new Diario2GridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Diario2" />
            <Diario2GridContainer grid={Diario2Grid} />
        </PageLayout>
    );
};

export default Diario2Page;