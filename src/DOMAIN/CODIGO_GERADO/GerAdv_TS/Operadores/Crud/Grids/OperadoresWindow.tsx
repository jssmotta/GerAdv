import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import OperadoresInc from "../Inc/Operadores";
import { IOperadores } from "../../Interfaces/interface.Operadores";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { OperadoresEmpty } from "@/app/GerAdv_TS/Models/Operadores";
import { useWindow } from "@/app/hooks/useWindows";

interface OperadoresWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedOperadores?: IOperadores;
    onSuccess: () => void;
    onError: () => void;
}

const OperadoresWindow: React.FC<OperadoresWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedOperadores,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/operadores/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedOperadores?.id}`);
        }

    }, [isMobile, router, selectedOperadores]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={597}
                    newWidth={1440}
                    id={(selectedOperadores?.id ?? 0).toString()}
                >
                    <OperadoresInc
                        id={selectedOperadores?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowOperadores: React.FC<OperadoresWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <OperadoresWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedOperadores={OperadoresEmpty()}>
        </OperadoresWindow>
    )
};

export default OperadoresWindow;