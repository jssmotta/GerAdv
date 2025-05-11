"use client";
import React from "react";
import { useIdParam } from "@/app/hooks/useIdParam";
import { NextNavigationService } from "@/app/services/NavigationService";
import { useRouter } from "next/navigation";
import Layout from '@/app/components/DrawerLayout';
import { LoadingSpinner } from "@/app/components/Cruds/LoadingSpinner";
import dynamic from 'next/dynamic';

const ProcessosParadosIncContainer = dynamic(
  () => import('@/app/GerAdv_TS/ProcessosParados/Components/ProcessosParadosIncContainer'),
  { ssr: false }
);

const ProcessosParadosPageInc: React.FC = () => {
    const router = useRouter();
    const id = useIdParam();
    const navigator = React.useMemo(() => new NextNavigationService(router), [router]);       

    return (
        <Layout>
            {id === null ? (
                <LoadingSpinner />
            ) : (
                <ProcessosParadosIncContainer id={id} navigator={navigator} />
            )}
        </Layout>
    );
};

export default ProcessosParadosPageInc;