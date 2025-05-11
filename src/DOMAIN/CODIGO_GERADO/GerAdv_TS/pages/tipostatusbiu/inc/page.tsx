"use client";
import React from "react";
import { useIdParam } from "@/app/hooks/useIdParam";
import { NextNavigationService } from "@/app/services/NavigationService";
import { useRouter } from "next/navigation";
import Layout from '@/app/components/DrawerLayout';
import { LoadingSpinner } from "@/app/components/Cruds/LoadingSpinner";
import dynamic from 'next/dynamic';

const TipoStatusBiuIncContainer = dynamic(
  () => import('@/app/GerAdv_TS/TipoStatusBiu/Components/TipoStatusBiuIncContainer'),
  { ssr: false }
);

const TipoStatusBiuPageInc: React.FC = () => {
    const router = useRouter();
    const id = useIdParam();
    const navigator = React.useMemo(() => new NextNavigationService(router), [router]);       

    return (
        <Layout>
            {id === null ? (
                <LoadingSpinner />
            ) : (
                <TipoStatusBiuIncContainer id={id} navigator={navigator} />
            )}
        </Layout>
    );
};

export default TipoStatusBiuPageInc;