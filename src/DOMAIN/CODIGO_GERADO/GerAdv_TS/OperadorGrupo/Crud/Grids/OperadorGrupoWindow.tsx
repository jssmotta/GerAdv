import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import OperadorGrupoInc from "../Inc/OperadorGrupo";
import { IOperadorGrupo } from "../../Interfaces/interface.OperadorGrupo";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { OperadorGrupoEmpty } from "@/app/GerAdv_TS/Models/OperadorGrupo";
import { useWindow } from "@/app/hooks/useWindows";

interface OperadorGrupoWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedOperadorGrupo?: IOperadorGrupo;
    onSuccess: () => void;
    onError: () => void;
}

const OperadorGrupoWindow: React.FC<OperadorGrupoWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedOperadorGrupo,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/operadorgrupo/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedOperadorGrupo?.id}`);
        }

    }, [isMobile, router, selectedOperadorGrupo]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedOperadorGrupo?.id ?? 0).toString()}
                >
                    <OperadorGrupoInc
                        id={selectedOperadorGrupo?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowOperadorGrupo: React.FC<OperadorGrupoWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <OperadorGrupoWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedOperadorGrupo={OperadorGrupoEmpty()}>
        </OperadorGrupoWindow>
    )
};

export default OperadorGrupoWindow;