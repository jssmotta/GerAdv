import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import FaseInc from "../Inc/Fase";
import { IFase } from "../../Interfaces/interface.Fase";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { FaseEmpty } from "@/app/GerAdv_TS/Models/Fase";
import { useWindow } from "@/app/hooks/useWindows";

interface FaseWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedFase?: IFase;
    onSuccess: () => void;
    onError: () => void;
}

const FaseWindow: React.FC<FaseWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedFase,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/fase/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedFase?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedFase]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedFase?.id ?? 0).toString()}
                >
                    <FaseInc
                        id={selectedFase?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowFase: React.FC<FaseWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <FaseWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedFase={FaseEmpty()}>
        </FaseWindow>
    )
};

export default FaseWindow;