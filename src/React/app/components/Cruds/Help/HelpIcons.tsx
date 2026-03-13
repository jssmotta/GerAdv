'use client';

import React from 'react';
import { SvgIcon } from '@progress/kendo-react-common';
import {
  plusIcon,
  filterIcon,
  gridIcon,
  searchIcon,
  calendarIcon,
  homeIcon,
  microphoneOutlineIcon,
  questionCircleIcon,
  fontShrinkIcon,
  fontGrowIcon,
  fileExcelIcon,
  filePdfIcon,
} from '@progress/kendo-svg-icons';

export const PlusIcon: React.FC<{ size?: number }> = ({ size = 18 }) => (
  <SvgIcon icon={plusIcon} style={{ width: size, height: size }} />
);

export const FilterIcon: React.FC<{ size?: number }> = ({ size = 18 }) => (
  <SvgIcon icon={filterIcon} style={{ width: size, height: size }} />
);

export const GridIcon: React.FC<{ size?: number }> = ({ size = 18 }) => (
  <SvgIcon icon={gridIcon} style={{ width: size, height: size }} />
);

export const MicIcon: React.FC<{ size?: number }> = ({ size = 18 }) => (
  <SvgIcon icon={microphoneOutlineIcon} style={{ width: size, height: size }} />
);

export const SearchIcon: React.FC<{ size?: number }> = ({ size = 18 }) => (
  <SvgIcon icon={searchIcon} style={{ width: size, height: size }} />
);

export const CalendarIcon: React.FC<{ size?: number }> = ({ size = 18 }) => (
  <SvgIcon icon={calendarIcon} style={{ width: size, height: size }} />
);

export const HomeIcon: React.FC<{ size?: number }> = ({ size = 18 }) => (
  <SvgIcon icon={homeIcon} style={{ width: size, height: size }} />
);

export const AIIcon: React.FC<{ size?: number }> = ({ size = 18 }) => (
  <SvgIcon icon={questionCircleIcon} style={{ width: size, height: size }} />
);

export const HelpIcon: React.FC<{ size?: number }> = ({ size = 18 }) => (
  <SvgIcon icon={questionCircleIcon} style={{ width: size, height: size }} />
);

export const SmallCardIcon: React.FC<{ size?: number }> = ({ size = 18 }) => (
  <SvgIcon icon={fontShrinkIcon} style={{ width: size, height: size }} />
);

export const FullCardIcon: React.FC<{ size?: number }> = ({ size = 18 }) => (
  <SvgIcon icon={fontGrowIcon} style={{ width: size, height: size }} />
);

export const PdfIcon: React.FC<{ size?: number }> = ({ size = 18 }) => (
  <SvgIcon icon={filePdfIcon} style={{ width: size, height: size }} />
);
export const ExcelIcon: React.FC<{ size?: number }> = ({ size = 18 }) => (
  <SvgIcon icon={fileExcelIcon} style={{ width: size, height: size }} />
);

export const ExitIcon: React.FC<{ size?: number }> = ({ size = 18 }) => (
  <svg width={size} height={size} viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
    <path d="M16 17L21 12L16 7" stroke="currentColor" strokeWidth="1.5" strokeLinecap="round" strokeLinejoin="round" />
    <path d="M21 12H9" stroke="currentColor" strokeWidth="1.5" strokeLinecap="round" strokeLinejoin="round" />
    <path d="M13 19H6a2 2 0 0 1-2-2V7a2 2 0 0 1 2-2h7" stroke="currentColor" strokeWidth="1.5" strokeLinecap="round" strokeLinejoin="round" />
  </svg>
);

 

export default null;
