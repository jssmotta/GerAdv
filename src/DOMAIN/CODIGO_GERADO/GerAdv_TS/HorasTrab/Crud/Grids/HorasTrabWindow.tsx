import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import HorasTrabInc from "../Inc/HorasTrab";
import { IHorasTrab } from "../../Interfaces/interface.HorasTrab";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { HorasTrabEmpty } from "@/app/GerAdv_TS/Models/HorasTrab";
import { useWindow } from "@/app/hooks/useWindows";

interface HorasTrabWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedHorasTrab?: IHorasTrab;
    onSuccess: () => void;
    onError: () => void;
}

const HorasTrabWindow: React.FC<HorasTrabWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedHorasTrab,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/horastrab/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedHorasTrab?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedHorasTrab]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={753}
                    newWidth={1440}
                    id={(selectedHorasTrab?.id ?? 0).toString()}
                >
                    <HorasTrabInc
                        id={selectedHorasTrab?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowHorasTrab: React.FC<HorasTrabWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <HorasTrabWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedHorasTrab={HorasTrabEmpty()}>
        </HorasTrabWindow>
    )
};

export default HorasTrabWindow;