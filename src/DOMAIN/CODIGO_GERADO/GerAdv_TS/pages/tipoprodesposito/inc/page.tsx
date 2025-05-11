"use client";
import React from "react";
import { useIdParam } from "@/app/hooks/useIdParam";
import { NextNavigationService } from "@/app/services/NavigationService";
import { useRouter } from "next/navigation";
import Layout from '@/app/components/DrawerLayout';
import { LoadingSpinner } from "@/app/components/Cruds/LoadingSpinner";
import dynamic from 'next/dynamic';

const TipoProDespositoIncContainer = dynamic(
  () => import('@/app/GerAdv_TS/TipoProDesposito/Components/TipoProDespositoIncContainer'),
  { ssr: false }
);

const TipoProDespositoPageInc: React.FC = () => {
    const router = useRouter();
    const id = useIdParam();
    const navigator = React.useMemo(() => new NextNavigationService(router), [router]);       

    return (
        <Layout>
            {id === null ? (
                <LoadingSpinner />
            ) : (
                <TipoProDespositoIncContainer id={id} navigator={navigator} />
            )}
        </Layout>
    );
};

export default TipoProDespositoPageInc;