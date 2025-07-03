// AreasJusticaGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { AreasJusticaGridAdapter } from '@/app/GerAdv_TS/AreasJustica/Adapter/AreasJusticaGridAdapter';
// Mock AreasJusticaGrid component
jest.mock('@/app/GerAdv_TS/AreasJustica/Crud/Grids/AreasJusticaGrid', () => () => <div data-testid='areasjustica-grid-mock' />);
describe('AreasJusticaGridAdapter', () => {
  it('should render AreasJusticaGrid component', () => {
    const adapter = new AreasJusticaGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('areasjustica-grid-mock')).toBeInTheDocument();
  });
});