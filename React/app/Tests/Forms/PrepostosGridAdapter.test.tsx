// PrepostosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { PrepostosGridAdapter } from '@/app/GerAdv_TS/Prepostos/Adapter/PrepostosGridAdapter';
// Mock PrepostosGrid component
jest.mock('@/app/GerAdv_TS/Prepostos/Crud/Grids/PrepostosGrid', () => () => <div data-testid='prepostos-grid-mock' />);
describe('PrepostosGridAdapter', () => {
  it('should render PrepostosGrid component', () => {
    const adapter = new PrepostosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('prepostos-grid-mock')).toBeInTheDocument();
  });
});