import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import GruposEmpresasInc from "../Inc/GruposEmpresas";
import { IGruposEmpresas } from "../../Interfaces/interface.GruposEmpresas";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { GruposEmpresasEmpty } from "@/app/GerAdv_TS/Models/GruposEmpresas";
import { useWindow } from "@/app/hooks/useWindows";

interface GruposEmpresasWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedGruposEmpresas?: IGruposEmpresas;
    onSuccess: () => void;
    onError: () => void;
}

const GruposEmpresasWindow: React.FC<GruposEmpresasWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedGruposEmpresas,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/gruposempresas/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedGruposEmpresas?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedGruposEmpresas]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={725}
                    newWidth={720}
                    id={(selectedGruposEmpresas?.id ?? 0).toString()}
                >
                    <GruposEmpresasInc
                        id={selectedGruposEmpresas?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowGruposEmpresas: React.FC<GruposEmpresasWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <GruposEmpresasWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedGruposEmpresas={GruposEmpresasEmpty()}>
        </GruposEmpresasWindow>
    )
};

export default GruposEmpresasWindow;