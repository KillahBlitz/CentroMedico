ALTER TABLE patients ADD COLUMN blood_type TEXT;
ALTER TABLE patients ADD COLUMN antecedents TEXT;

ALTER TABLE consulations ADD COLUMN type_consultation TEXT;
ALTER TABLE consulations ADD COLUMN temperature REAL;
ALTER TABLE consulations ADD COLUMN heart_rate REAL;
ALTER TABLE consulations ADD COLUMN respiratory_rate REAL;
ALTER TABLE consulations ADD COLUMN support_studies TEXT;
ALTER TABLE consulations ADD COLUMN diagnosis_treatment TEXT;

