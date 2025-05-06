"use client";
import React from "react";
import { useIdParam } from "@/app/hooks/useIdParam";
import { NextNavigationService } from "@/app/services/NavigationService";
import { useRouter } from "next/navigation";
import Layout from '@/app/paginas/DrawerLayout';
import { LoadingSpinner } from "@/app/components/LoadingSpinner";
import dynamic from 'next/dynamic';

const OperadorIncContainer = dynamic(
  () => import('@/app/GerAdv_TS/Operador/Components/OperadorIncContainer'),
  { ssr: false }
);

const OperadorPageInc: React.FC = () => {
    const router = useRouter();
    const id = useIdParam();
    const navigator = React.useMemo(() => new NextNavigationService(router), [router]);       

    return (
        <Layout>
            {id === null ? (
                <LoadingSpinner />
            ) : (
                <OperadorIncContainer id={id} navigator={navigator} />
            )}
        </Layout>
    );
};

export default OperadorPageInc;