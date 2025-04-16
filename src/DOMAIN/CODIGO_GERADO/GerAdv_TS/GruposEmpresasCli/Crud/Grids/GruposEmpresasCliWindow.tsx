import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import GruposEmpresasCliInc from "../Inc/GruposEmpresasCli";
import { IGruposEmpresasCli } from "../../Interfaces/interface.GruposEmpresasCli";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { GruposEmpresasCliEmpty } from "@/app/GerAdv_TS/Models/GruposEmpresasCli";
import { useWindow } from "@/app/hooks/useWindows";

interface GruposEmpresasCliWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedGruposEmpresasCli?: IGruposEmpresasCli;
    onSuccess: () => void;
    onError: () => void;
}

const GruposEmpresasCliWindow: React.FC<GruposEmpresasCliWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedGruposEmpresasCli,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/gruposempresascli/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedGruposEmpresasCli?.id}`);
        }

    }, [isMobile, router, selectedGruposEmpresasCli]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedGruposEmpresasCli?.id ?? 0).toString()}
                >
                    <GruposEmpresasCliInc
                        id={selectedGruposEmpresasCli?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowGruposEmpresasCli: React.FC<GruposEmpresasCliWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <GruposEmpresasCliWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedGruposEmpresasCli={GruposEmpresasCliEmpty()}>
        </GruposEmpresasCliWindow>
    )
};

export default GruposEmpresasCliWindow;