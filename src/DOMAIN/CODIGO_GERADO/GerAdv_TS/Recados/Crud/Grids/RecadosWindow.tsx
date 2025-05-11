import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import RecadosInc from "../Inc/Recados";
import { IRecados } from "../../Interfaces/interface.Recados";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { RecadosEmpty } from "@/app/GerAdv_TS/Models/Recados";
import { useWindow } from "@/app/hooks/useWindows";

interface RecadosWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedRecados?: IRecados;
    onSuccess: () => void;
    onError: () => void;
}

const RecadosWindow: React.FC<RecadosWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedRecados,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/recados/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedRecados?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedRecados]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={905}
                    newWidth={1440}
                    id={(selectedRecados?.id ?? 0).toString()}
                >
                    <RecadosInc
                        id={selectedRecados?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowRecados: React.FC<RecadosWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <RecadosWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedRecados={RecadosEmpty()}>
        </RecadosWindow>
    )
};

export default RecadosWindow;