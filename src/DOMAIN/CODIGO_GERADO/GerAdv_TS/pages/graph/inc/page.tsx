"use client";
import React from "react";
import { useIdParam } from "@/app/hooks/useIdParam";
import { NextNavigationService } from "@/app/services/NavigationService";
import { useRouter } from "next/navigation";
import Layout from '@/app/components/DrawerLayout';
import { LoadingSpinner } from "@/app/components/Cruds/LoadingSpinner";
import dynamic from 'next/dynamic';

const GraphIncContainer = dynamic(
  () => import('@/app/GerAdv_TS/Graph/Components/GraphIncContainer'),
  { ssr: false }
);

const GraphPageInc: React.FC = () => {
    const router = useRouter();
    const id = useIdParam();
    const navigator = React.useMemo(() => new NextNavigationService(router), [router]);       

    return (
        <Layout>
            {id === null ? (
                <LoadingSpinner />
            ) : (
                <GraphIncContainer id={id} navigator={navigator} />
            )}
        </Layout>
    );
};

export default GraphPageInc;