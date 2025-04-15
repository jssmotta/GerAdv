import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import EnquadramentoEmpresaInc from "../Inc/EnquadramentoEmpresa";
import { IEnquadramentoEmpresa } from "../../Interfaces/interface.EnquadramentoEmpresa";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { EnquadramentoEmpresaEmpty } from "@/app/GerAdv_TS/Models/EnquadramentoEmpresa";
import { useWindow } from "@/app/hooks/useWindows";

interface EnquadramentoEmpresaWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedEnquadramentoEmpresa?: IEnquadramentoEmpresa;
    onSuccess: () => void;
    onError: () => void;
}

const EnquadramentoEmpresaWindow: React.FC<EnquadramentoEmpresaWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedEnquadramentoEmpresa,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/enquadramentoempresa/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedEnquadramentoEmpresa?.id}`);
        }

    }, [isMobile, router, selectedEnquadramentoEmpresa]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedEnquadramentoEmpresa?.id ?? 0).toString()}
                >
                    <EnquadramentoEmpresaInc
                        id={selectedEnquadramentoEmpresa?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowEnquadramentoEmpresa: React.FC<EnquadramentoEmpresaWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <EnquadramentoEmpresaWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedEnquadramentoEmpresa={EnquadramentoEmpresaEmpty()}>
        </EnquadramentoEmpresaWindow>
    )
};

export default EnquadramentoEmpresaWindow;