import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import AreasJusticaInc from "../Inc/AreasJustica";
import { IAreasJustica } from "../../Interfaces/interface.AreasJustica";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { AreasJusticaEmpty } from "@/app/GerAdv_TS/Models/AreasJustica";
import { useWindow } from "@/app/hooks/useWindows";

interface AreasJusticaWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedAreasJustica?: IAreasJustica;
    onSuccess: () => void;
    onError: () => void;
}

const AreasJusticaWindow: React.FC<AreasJusticaWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedAreasJustica,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/areasjustica/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedAreasJustica?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedAreasJustica]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedAreasJustica?.id ?? 0).toString()}
                >
                    <AreasJusticaInc
                        id={selectedAreasJustica?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowAreasJustica: React.FC<AreasJusticaWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <AreasJusticaWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedAreasJustica={AreasJusticaEmpty()}>
        </AreasJusticaWindow>
    )
};

export default AreasJusticaWindow;