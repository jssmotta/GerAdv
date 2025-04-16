"use client";
import React from "react";
import { useIdParam } from "@/app/hooks/useIdParam";
import { NextNavigationService } from "@/app/services/NavigationService";
import { useRouter } from "next/navigation";
import Layout from '@/app/paginas/DrawerLayout';
import { LoadingSpinner } from "@/app/components/LoadingSpinner";
import dynamic from 'next/dynamic';

const FuncionariosIncContainer = dynamic(
  () => import('@/app/GerAdv_TS/Funcionarios/Components/FuncionariosIncContainer'),
  { ssr: false }
);

const FuncionariosPageInc: React.FC = () => {
    const router = useRouter();
    const id = useIdParam();
    const navigator = React.useMemo(() => new NextNavigationService(router), [router]);       

    return (
        <Layout>
            {id === null ? (
                <LoadingSpinner />
            ) : (
                <FuncionariosIncContainer id={id} navigator={navigator} />
            )}
        </Layout>
    );
};

export default FuncionariosPageInc;