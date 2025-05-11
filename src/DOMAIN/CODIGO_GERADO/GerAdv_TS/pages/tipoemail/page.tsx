"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { TipoEMailGridAdapter } from "@/app/GerAdv_TS/TipoEMail/Adapter/TipoEMailGridAdapter";
import TipoEMailGridContainer from "@/app/GerAdv_TS/TipoEMail/Components/TipoEMailGridContainer";

const TipoEMailPage: React.FC = () => {
    const TipoEMailGrid = new TipoEMailGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Tipo E Mail" />
            <TipoEMailGridContainer grid={TipoEMailGrid} />
        </PageLayout>
    );
};

export default TipoEMailPage;