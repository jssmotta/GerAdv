import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import ColaboradoresInc from "../Inc/Colaboradores";
import { IColaboradores } from "../../Interfaces/interface.Colaboradores";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ColaboradoresEmpty } from "@/app/GerAdv_TS/Models/Colaboradores";
import { useWindow } from "@/app/hooks/useWindows";

interface ColaboradoresWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedColaboradores?: IColaboradores;
    onSuccess: () => void;
    onError: () => void;
}

const ColaboradoresWindow: React.FC<ColaboradoresWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedColaboradores,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/colaboradores/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedColaboradores?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedColaboradores]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={714}
                    newWidth={1440}
                    id={(selectedColaboradores?.id ?? 0).toString()}
                >
                    <ColaboradoresInc
                        id={selectedColaboradores?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowColaboradores: React.FC<ColaboradoresWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ColaboradoresWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedColaboradores={ColaboradoresEmpty()}>
        </ColaboradoresWindow>
    )
};

export default ColaboradoresWindow;