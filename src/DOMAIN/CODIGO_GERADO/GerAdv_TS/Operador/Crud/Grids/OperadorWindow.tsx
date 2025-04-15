import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import OperadorInc from "../Inc/Operador";
import { IOperador } from "../../Interfaces/interface.Operador";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { OperadorEmpty } from "@/app/GerAdv_TS/Models/Operador";
import { useWindow } from "@/app/hooks/useWindows";

interface OperadorWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedOperador?: IOperador;
    onSuccess: () => void;
    onError: () => void;
}

const OperadorWindow: React.FC<OperadorWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedOperador,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/operador/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedOperador?.id}`);
        }

    }, [isMobile, router, selectedOperador]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={905}
                    newWidth={1440}
                    id={(selectedOperador?.id ?? 0).toString()}
                >
                    <OperadorInc
                        id={selectedOperador?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowOperador: React.FC<OperadorWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <OperadorWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedOperador={OperadorEmpty()}>
        </OperadorWindow>
    )
};

export default OperadorWindow;